using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith
{
    public class NodeRegistryService : NodeRegistry.NodeRegistryBase
    {
        private readonly ILogger<NodeRegistryService> _logger;
        private monolith.Server.FileRegistry fileRegistry { get; }
        private monolith.Server.NodeRegistry nodeRegistry { get; }

        public NodeRegistryService(
            // monolith.Server.FileRegistry fileRegistry,  // maybe needing it, maybe not, lets see.
            monolith.Server.NodeRegistry nodeRegistry, 
            ILogger<NodeRegistryService> logger
        ) {
            _logger = logger;
            this.fileRegistry = fileRegistry;
            this.nodeRegistry = nodeRegistry;
        }

        public async override Task<NodeAuthenticationReply> Authenticate(NodeAuthenticationRequest request, ServerCallContext context) {
            Server.Node node = new Server.Node(request.Identifier);
            await this.nodeRegistry.Register(node);

            return new NodeAuthenticationReply {
                Status = true
            };
        }
    }
}
