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
        public async Task TestDatabaseSaving_Container()
        {
            PostgresProvider datahoarderMainUserProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarder_superuser", "datahoarder_superuser", "postgres");
            using var conn = await datahoarderMainUserProvider.NewConnection();
            await conn.ExecuteAsync("SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'datahoarder_test' OR datname = 'datahoarder_template';"); // Drop Old Database Connections
            await conn.ExecuteAsync("DROP DATABASE IF EXISTS datahoarder_test;");
            await conn.ExecuteAsync("CREATE DATABASE datahoarder_test TEMPLATE datahoarder_template;");

            PostgresProvider postgresProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarderfs", "datahoarderfs", "datahoarder_test");
            monolith.Tracker.ContainerRegistry containerRegistry = new monolith.Tracker.ContainerRegistry(postgresProvider);

            var testContainer = new monolith.Tracker.Container {
                Name = "alt.binaries.pictures.erotica.furry",
                Creator = Guid.NewGuid().ToString(),
            };
            var registeredContainer = await containerRegistry.Register(testContainer);
            Assert.NotNull(registeredContainer);

            var fetchedContainer = await containerRegistry.Get(registeredContainer);
            Assert.NotNull(fetchedContainer);
            Assert.Equal(fetchedContainer.Name, testContainer.Name);
            Assert.Equal(fetchedContainer.Creator, testContainer.Creator);

            NpgsqlConnection.ClearAllPools();
        }

        [Fact]
        public async Task TestDatabaseSaving_Files()
        {
            PostgresProvider datahoarderMainUserProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarder_superuser", "datahoarder_superuser", "postgres");
            using var conn = await datahoarderMainUserProvider.NewConnection();
            await conn.ExecuteAsync("SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'datahoarder_test' OR datname = 'datahoarder_template';"); // Drop Old Database Connections
            await conn.ExecuteAsync("DROP DATABASE IF EXISTS datahoarder_test;");
            await conn.ExecuteAsync("CREATE DATABASE datahoarder_test TEMPLATE datahoarder_template;");

            PostgresProvider postgresProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarderfs", "datahoarderfs", "datahoarder_test");
            monolith.Tracker.FileRegistry fileRegistry = new monolith.Tracker.FileRegistry(postgresProvider);
            monolith.Tracker.ContainerRegistry containerRegistry = new monolith.Tracker.ContainerRegistry(postgresProvider);

            var testContainer = new monolith.Tracker.Container {
                Name = "alt.binaries.pictures.erotica.furry",
                Creator = Guid.NewGuid().ToString(),
            };
            var registeredContainer = await containerRegistry.Register(testContainer);

            var testFile = new monolith.Tracker.File {
                ContainerID = registeredContainer,
                Filename = $"testFile{ Guid.NewGuid() }.txt",
                Owner = Guid.NewGuid().ToString(),
            };
            var registeredFile = await fileRegistry.Register(testFile);
            Assert.NotNull(registeredFile);

            var fetchedFile = await fileRegistry.Get(registeredFile);
            Assert.NotNull(fetchedFile);
            Assert.Equal(fetchedFile.Filename, testFile.Filename);
            Assert.Equal(fetchedFile.Owner, testFile.Owner);
            
            NpgsqlConnection.ClearAllPools();
        }
    }
}
