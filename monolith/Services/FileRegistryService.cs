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

        public FileRegistryService(
            monolith.Tracker.FileRegistry fileRegistry,
            monolith.Tracker.NodeRegistry nodeRegistry,
            ILogger<FileRegistryService> logger
        )
        {
            _logger = logger;
            this.fileRegistry = fileRegistry;
            this.nodeRegistry = nodeRegistry;
        }

        public async override Task<FileRegisterReply> Register(FileRegisterRequest request, ServerCallContext context)
        {
            Guid id = await this.fileRegistry.Register(new Tracker.File { 
                Filename = request.Filename,
                Owner = context.GetHttpContext().User.Identity.Name,
            });

            return new FileRegisterReply
            {
                Id = id.ToString(),
            };
        }
        public async override Task<FileBrowseReply> Browse(FileBrowseRequest request, ServerCallContext context)
        {
            // context.GetHttpContext().User
            var reply = new FileBrowseReply { };
            Tracker.File[] res = await this.fileRegistry.Browse();

            foreach (var file in res)
                reply.Files.Add(new File {
                    Id = file.Id.ToString(),
                    Owner = file.Owner,
                    Filename = file.Filename,
                });

            return reply;
        }
        public async override Task<FileGetReply> Get(FileGetRequest request, ServerCallContext context)
        {
            // await Server.FileRegistry.Instance.Register(new Server.File(request.Filename));
            Guid parsed;
            var reply = new FileGetReply {
             };
            if (Guid.TryParse(request.Id, out parsed)) {
                reply.Where2Get.Add("bla");
            }
            return (await Task.FromResult(reply));
        }
    }
}
