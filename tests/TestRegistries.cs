using System;
using Xunit;

using monolith;
using System.Threading.Tasks;

using Dapper;
using Xunit.Sdk;
using System.Collections.Generic;
using System.Linq;
using Npgsql;

namespace tests
{
    public class AlphabeticalOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
                where TTestCase : Xunit.Abstractions.ITestCase
        {
            var result = testCases.ToList();
            result.Sort((x, y) => StringComparer.OrdinalIgnoreCase.Compare(x.TestMethod.Method.Name, y.TestMethod.Method.Name));
            return result;
        }
    }


    [Collection("Testing Registries")]
    [TestCaseOrderer("tests.AlphabeticalOrderer", "TestRegistries")]
    public class TestRegistries
    {

        [Fact]
        public async Task TestDatabaseSaving()
        {
            //TODO make this somehow singleton (with await xD)
            PostgresProvider datahoarderMainUserProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarder_superuser", "datahoarder_superuser", "postgres");
            using var conn = await datahoarderMainUserProvider.NewConnection();
            await conn.ExecuteAsync("SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'datahoarder_test' OR datname = 'datahoarder_template';"); // Drop Old Database Connections
            await conn.ExecuteAsync("DROP DATABASE IF EXISTS datahoarder_test;");
            await conn.ExecuteAsync("CREATE DATABASE datahoarder_test TEMPLATE datahoarder_template;");
            NpgsqlConnection.ClearAllPools();


            PostgresProvider postgresProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarderfs", "datahoarderfs", "datahoarder_test");
            monolith.Tracker.ContainerRegistry containerRegistry = new monolith.Tracker.ContainerRegistry(postgresProvider);
            monolith.Tracker.FileRegistry fileRegistry = new monolith.Tracker.FileRegistry(postgresProvider);
            monolith.Tracker.FileChunkRegistry fileChunkRegistry = new monolith.Tracker.FileChunkRegistry(postgresProvider);
            monolith.Tracker.FileVersionRegistry fileVersionRegistry = new monolith.Tracker.FileVersionRegistry(postgresProvider);

            var testContainer = new monolith.Tracker.Container {
                Name = "alt.binaries.pictures.erotica.furry",
                Creator = Guid.NewGuid().ToString(),
            };
            var registeredContainer = await containerRegistry.Register(testContainer);

            var testFile = new monolith.Tracker.File {
                ContainerId = registeredContainer,
                Filename = $"testFile{ Guid.NewGuid() }.txt",
                Owner = Guid.NewGuid().ToString(),
            };
            var registeredFile = await fileRegistry.Register(testFile);

            var fetchedFile = await fileRegistry.Get(registeredFile);
            Assert.Equal(testFile.ContainerId, fetchedFile.ContainerId);
            Assert.Equal(testFile.Filename, fetchedFile.Filename);
            Assert.Equal(testFile.Owner, fetchedFile.Owner);
            
            // Testing Chunking Saving
            const int testSizeMB = 10;
            var testVersion = new monolith.Tracker.FileVersion {
                FileId = fetchedFile.Id,
                Date = DateTime.Now,
                Size = 1024 * 1024 * testSizeMB, // 10 MB
            };
            var registredVersion = await fileVersionRegistry.Register(testVersion);
            System.Diagnostics.Trace.WriteLine("registred Version" + registredVersion.ToString());
            
            var fetchedVersion = await fileVersionRegistry.Get(registredVersion);
            Assert.Equal(testVersion.FileId, fetchedVersion.FileId);
            Assert.Equal(testVersion.Date, fetchedVersion.Date, TimeSpan.FromMilliseconds(5));
            Assert.Equal(testVersion.Size, fetchedVersion.Size);

            for (int i = 0;i < testSizeMB; i++) {
                var testChunk = new monolith.Tracker.FileChunk {
                    FileId = fetchedVersion.FileId,
                    Order = i,
                    Size = 1024 * 1024 * 1 // 1 MB
                };
                var registredChunk = await fileChunkRegistry.Register(testChunk);

                var fetchedChunk = await fileChunkRegistry.Get(registredChunk);
                Assert.Equal(fetchedChunk.FileId, testChunk.FileId);
                Assert.Equal(fetchedChunk.Order, testChunk.Order);
                Assert.Equal(fetchedChunk.Size, testChunk.Size);
            }

            //NpgsqlConnection.ClearAllPools();
        }
    }
}
