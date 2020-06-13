using System;
using Xunit;

using monolith;
using System.Threading.Tasks;

using Dapper;
namespace tests
{
    public class TestFileRegistry
    {
        [Fact]
        public async Task TestDatabaseSaving()
        {
            PostgresProvider datahoarderMainUserProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarderfs", "datahoarderfs", "datahoarder_template");
            using var conn = await datahoarderMainUserProvider.NewConnection();
            await conn.ExecuteAsync("SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'datahoarder_test';"); // Drop Old Database Connections
            await conn.ExecuteAsync("DROP DATABASE IF EXISTS datahoarder_test;");
            await conn.ExecuteAsync("CREATE DATABASE datahoarder_test TEMPLATE datahoarder_template;");
            // await conn.ExecuteAsync("GRANT ALL ON DATABASE datahoarder_test TO datahoarderfs;");
            // CREATE DATABASE datahoarder_test TEMPLATE datahoarder_template;
            // GRANT ALL ON DATABASE datahoarder_test TO datahoarderfs;

            PostgresProvider postgresProvider = new monolith.PostgresProvider("10.13.37.81", "datahoarderfs", "datahoarderfs", "datahoarder_test");
            monolith.Server.FileRegistry fileRegistry = new monolith.Server.FileRegistry(postgresProvider);

            var testFile = new monolith.Server.File {
                Filename = $"testFile{ Guid.NewGuid() }.txt",
                Owner = Guid.NewGuid().ToString(),
            };
            var registeredFile = await fileRegistry.Register(testFile);
            Assert.NotNull(registeredFile);

            var fetchedFile = await fileRegistry.Get(registeredFile);
            Assert.NotNull(fetchedFile);
            Assert.Equal(fetchedFile.Filename, testFile.Filename);
            Assert.Equal(fetchedFile.Owner, testFile.Owner);
        }
    }
}
