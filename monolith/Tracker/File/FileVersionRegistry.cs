using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Dapper;

namespace monolith.Tracker
{
    public class FileVersionRegistry
    {
        public PostgresProvider postgresProvider { get; }

        public FileVersionRegistry(PostgresProvider postgresProvider)
        {
            this.postgresProvider = postgresProvider;
            Console.WriteLine("[FileVersionRegistry] has been initialized");
        }
        public async Task<Guid> Register(FileVersion fileVersion)
        {
            var id = Guid.NewGuid();
            using var conn = await postgresProvider.NewConnection();
            await conn.ExecuteAsync("INSERT INTO fileversions(id, fileid, date, size) VALUES (@Id, @FileId, @Date, @Size)", new {
                Id = id,
                FileId = fileVersion.FileId,
                Date = fileVersion.Date,
                Size = fileVersion.Size,
            });
            return id;
        }
        public async Task<FileVersion[]> Browse(Guid fileId, int page = 0)
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<FileVersion>("SELECT * FROM fileversions WHERE fileid = @FileId LIMIT @Limit OFFSET @Offset", new {
                FileId = fileId,
                Limit = 100,
                Offset = page * 100,
            });
            return res.ToArray();
        }
        public async Task<FileVersion> Get(Guid id)
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<FileVersion>("SELECT * FROM fileversions WHERE id = @Id LIMIT 1", new {
                Id = id,
            });
            return res.First();
        }
    }
}
