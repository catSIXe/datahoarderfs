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
        private readonly ILogger<FileRegistryService> _logger;
        public FileRegistryService(ILogger<FileRegistryService> logger)
        {
            _logger = logger;
        }

        public async override Task<FileRegisterReply> Register(FileRegisterRequest request, ServerCallContext context) {
            await Server.FileRegistry.Instance.Register(new Server.File(request.Filename));

            return new FileRegisterReply {
                Success = true
            };
        }
        public async override Task<FileBrowseReply> Browse(FileBrowseRequest request, ServerCallContext context) {
            // context.GetHttpContext().User
            var reply = new FileBrowseReply {};
            Server.File[] res = await Server.FileRegistry.Instance.Browse();

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
