using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Dapper;

namespace monolith.Tracker
{
    public class FileChunkRegistry
    {
        public PostgresProvider postgresProvider { get; }

        public FileChunkRegistry(PostgresProvider postgresProvider)
        {
            this.postgresProvider = postgresProvider;
            Console.WriteLine("[FileChunkRegistry] has been initialized");
        }
        public async Task<Guid> Register(File file)
        {
            var id = Guid.NewGuid();
            using var conn = await postgresProvider.NewConnection();
            await conn.ExecuteAsync("INSERT INTO files(id, container_id, filename, owner) VALUES (@Id, @ContainerId, @Filename, @Owner)", new {
                Id = id,
                ContainerId = file.ContainerID,
                Filename = file.Filename,
                Owner = file.Owner
            });
            return id;
        }
        public async Task<File[]> Browse(Guid containerId, int page = 0)
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<File>("SELECT * FROM files WHERE container_id = @ContainerId LIMIT @Limit OFFSET @Offset", new {
                ContainerId = containerId,
                Limit = 100,
                Offset = page * 100,
            });
            return res.ToArray();
        }
        public async Task<File> Get(Guid id)
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<File>("SELECT * FROM files WHERE Id = @Id LIMIT 1", new {
                Id = id,
            });
            return res.First();
        }
    }
}
