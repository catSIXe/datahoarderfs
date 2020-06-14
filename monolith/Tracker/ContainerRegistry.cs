using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Dapper;

namespace monolith.Tracker
{
    public class ContainerRegistry
    {
        public PostgresProvider postgresProvider { get; }

        public ContainerRegistry(PostgresProvider postgresProvider)
        {
            this.postgresProvider = postgresProvider;
            Console.WriteLine("[ContainerRegistry] has been initialized");
        }
        public async Task<Guid> Register(Container container)
        {
            var id = Guid.NewGuid();
            using var conn = await postgresProvider.NewConnection();
            await conn.ExecuteAsync("INSERT INTO containers(id, name, creator) VALUES (@Id, @Name, @Creator)", new {
                Id = id,
                Name = container.Name,
                Creator = container.Creator
            });
            return id;
        }
        public async Task<Container[]> Browse()
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<Container>("SELECT * FROM containers");
            return res.ToArray();
        }
        public async Task<Container> Get(Guid id)
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<Container>("SELECT * FROM containers WHERE Id = @Id LIMIT 1", new {
                Id = id,
            });
            return res.First();
        }
    }
}
