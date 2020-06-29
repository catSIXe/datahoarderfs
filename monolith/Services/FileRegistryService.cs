using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith
{
    public class FileRegistryService : FileRegistry.FileRegistryBase
    {
        private ILogger<FileRegistryService> _logger { get; }

        private monolith.Tracker.FileRegistry fileRegistry { get; }
        private monolith.Tracker.NodeRegistry nodeRegistry { get; }
        private monolith.Tracker.VersionRegistry fileVersionRegistry { get; }
        private monolith.Tracker.ChunkRegistry fileChunkRegistry { get; }
        

        public FileRegistryService(
            monolith.Tracker.FileRegistry fileRegistry,
            monolith.Tracker.VersionRegistry fileVersionRegistry,
            monolith.Tracker.ChunkRegistry fileChunkRegistry,

            monolith.Tracker.NodeRegistry nodeRegistry,
            ILogger<FileRegistryService> logger
        )
        {
            _logger = logger;

            this.fileRegistry = fileRegistry;
            this.fileVersionRegistry = fileVersionRegistry;
            this.fileChunkRegistry = fileChunkRegistry;

            this.nodeRegistry = nodeRegistry;
        }

        public async override Task<FileRegisterReply> Register(FileRegisterRequest request, ServerCallContext context)
        {
            Guid id = await this.fileRegistry.Register(new Tracker.File { 
                Filename = request.Filename,
                ContainerId = Guid.Parse(request.Container),
                Owner = context.GetHttpContext().User.Identity.Name,
            });

            return new FileRegisterReply
            {
                Id = id.ToString(),
            };
        }
        public async override Task<FileBrowseReply> Browse(FileBrowseRequest request, ServerCallContext context)
        {
            Guid containerId;
            if (Guid.TryParse(request.Container, out containerId)) {
                // context.GetHttpContext().User
                var reply = new FileBrowseReply { };
                Tracker.File[] res = await this.fileRegistry.Browse(containerId, request.Page);

                foreach (var file in res)
                    reply.Files.Add(new File {
                        Id = file.Id.ToString(),
                        Owner = file.Owner,
                        Filename = file.Filename,
                    });

                return reply;
            }
            throw new Exception("invalid container guid");
        }
        /*public async override Task<FileGetReply> Get(FileGetRequest request, ServerCallContext context)
        {
            // await Server.FileRegistry.Instance.Register(new Server.File(request.Filename));
            Guid parsed;
            var reply = new FileGetReply {
             };
            if (Guid.TryParse(request.Id, out parsed)) {
                reply.Where2Get.Add("bla");
            }
            return (await Task.FromResult(reply));
        }*/

        // Dummy Functions
        public async override Task<FileInformationReply> GetFileInformation(FileInformationRequest request, ServerCallContext context)
        {
            // await Server.FileRegistry.Instance.Register(new Server.File(request.Filename));
            Guid parsed;
            var reply = new FileInformationReply { };
            if (Guid.TryParse(request.Id, out parsed)) {
            }
            return (await Task.FromResult(reply));
        }
        public async override Task<FileHistoryReply> GetFileHistory(FileHistoryRequest request, ServerCallContext context)
        {
            Guid parsed;
            var reply = new FileHistoryReply { };
            if (Guid.TryParse(request.Id, out parsed)) {
            }
            return (await Task.FromResult(reply));
        }
        public async override Task<FileChunksReply> GetFileChunks(FileChunksRequest request, ServerCallContext context)
        {
            Guid parsed;
            var reply = new FileChunksReply { };
            if (Guid.TryParse(request.Id, out parsed)) {
            }
            return (await Task.FromResult(reply));
        }
    }
}
