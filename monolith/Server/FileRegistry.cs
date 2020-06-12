using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Dapper;

namespace monolith.Server
{
    public class FileRegistry
    {
        public PostgresProvider postgresProvider { get; }
        public Dictionary<string, File> registry;

        public FileRegistry(PostgresProvider postgresProvider)
        {
            this.postgresProvider = postgresProvider;
            Console.WriteLine("[FileRegistry] has been initialized");
            this.registry = new Dictionary<string, File>();
        }
        public async Task<Guid> Register(File file)
        {
            var id = Guid.NewGuid();
            using var conn = await postgresProvider.NewConnection();
            await conn.ExecuteAsync("INSERT INTO files(id, filename) VALUES (@Id, @filename) ON CONFLICT(filename) DO NOTHING", new {
                Id = id,
                filename = file.Filename,
            });
            // this.registry.Add(file.Filename, file);
            return id;
        }
        public async Task<File[]> Browse()
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<File>("SELECT * FROM files LIMIT 10");
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
