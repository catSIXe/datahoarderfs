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
        public async Task<Guid> Register(FileChunk fileChunk)
        {
            var id = Guid.NewGuid();
            using var conn = await postgresProvider.NewConnection();
            await conn.ExecuteAsync("INSERT INTO chunks(id, fileid, \"order\", size) VALUES (@Id, @FileId, @Order, @Size)", new {
                Id = id,
                Order = fileChunk.Order,
                FileId = fileChunk.FileId,
                Size = fileChunk.Size
            });
            return id;
        }
        public async Task<FileChunk[]> Browse(Guid fileVersionId, int page = 0)
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<FileVersionsChunksStruct>("SELECT * FROM file_versions_chunks WHERE fileversion_id = @FileVersionId LIMIT @Limit OFFSET @Offset", new {
                FileVersionId = fileVersionId,
                Limit = 100,
                Offset = page * 100,
            });

            //TODO: subselect for the chunks themself
            // res.ToArray()
            return null;
        }
        public async Task<FileChunk> Get(Guid id)
        {
            using var conn = await postgresProvider.NewConnection();
            var res = await conn.QueryAsync<FileChunk>("SELECT * FROM chunks WHERE Id = @Id LIMIT 1", new {
                Id = id,
            });
            return res.First();
        }
    }
}
