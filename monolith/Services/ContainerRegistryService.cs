using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith
{
    public class ContainerRegistryService : ContainerRegistry.ContainerRegistryBase
    {
        private ILogger<ContainerRegistryService> _logger { get; }

        private monolith.Tracker.FileRegistry fileRegistry { get; }
        private monolith.Tracker.NodeRegistry nodeRegistry { get; }
        private monolith.Tracker.ContainerRegistry containerRegistry { get; }

        public ContainerRegistryService(
            monolith.Tracker.FileRegistry fileRegistry,
            monolith.Tracker.NodeRegistry nodeRegistry,
            monolith.Tracker.ContainerRegistry containerRegistry,
            ILogger<ContainerRegistryService> logger
        )
        {
            _logger = logger;
            this.fileRegistry = fileRegistry;
            this.nodeRegistry = nodeRegistry;
            this.containerRegistry = containerRegistry;
        }

        public async override Task<ContainerRegisterReply> Register(ContainerRegisterRequest request, ServerCallContext context)
        {
            foreach (var header in context.GetHttpContext().Request.Headers)
                _logger.LogInformation($"${ header.Key }={ header.Value }");

            _logger.LogInformation($"[ContainerRegistryService] Register Container { request.Name } by { context.GetHttpContext().User.Identity.Name }");
            Guid id = await this.containerRegistry.Register(new Tracker.Container { 
                Name = request.Name,
                Creator = context.GetHttpContext().User.Identity.Name,
            });

            return new ContainerRegisterReply
            {
                Id = id.ToString(),
            };
        }
        public async override Task<ContainerBrowseReply> Browse(ContainerBrowseRequest request, ServerCallContext context)
        {
            var reply = new ContainerBrowseReply { };
            Tracker.Container[] res = await this.containerRegistry.Browse();

            foreach (var container in res)
                reply.Containers.Add(new Container {
                    Id = container.Id.ToString(),
                    Creator = container.Creator,
                    Name = container.Name,
                });

            return reply;
        }
    }
}
