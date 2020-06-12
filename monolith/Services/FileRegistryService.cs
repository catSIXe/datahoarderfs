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

        private monolith.Server.FileRegistry fileRegistry { get; }
        private monolith.Server.NodeRegistry nodeRegistry { get; }

        public FileRegistryService(
            monolith.Server.FileRegistry fileRegistry, 
            monolith.Server.NodeRegistry nodeRegistry, 
            ILogger<FileRegistryService> logger
        ) {
            _logger = logger;
            this.fileRegistry = fileRegistry;
            this.nodeRegistry = nodeRegistry;
        }

        public async override Task<FileRegisterReply> Register(FileRegisterRequest request, ServerCallContext context) {
            await this.fileRegistry.Register(new Server.File(request.Filename));

            return new FileRegisterReply {
                Success = true
            };
        }
        public async override Task<FileBrowseReply> Browse(FileBrowseRequest request, ServerCallContext context) {
            // context.GetHttpContext().User
            var reply = new FileBrowseReply {};
            Server.File[] res = await this.fileRegistry.Browse();

            foreach(var file in res) 
                reply.Filenames.Add(file.Filename);

            return reply;
        }
        public async override Task<FileGetReply> Get(FileGetRequest request, ServerCallContext context) {
            // await Server.FileRegistry.Instance.Register(new Server.File(request.Filename));
            var reply = new FileGetReply {};
            reply.Where2Get.Add("bla");
            return reply;
        }
    }
}
