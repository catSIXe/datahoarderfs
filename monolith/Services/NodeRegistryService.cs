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
        public NodeRegistryService(ILogger<NodeRegistryService> logger)
        {
            _logger = logger;
        }

        public async override Task<NodeAuthenticationReply> Authenticate(NodeAuthenticationRequest request, ServerCallContext context) {
            Server.Node node = new Server.Node(request.Identifier);
            await Server.NodeRegistry.Instance.Register(node);

            return new NodeAuthenticationReply {
                Status = true
            };
        }
    }
}
