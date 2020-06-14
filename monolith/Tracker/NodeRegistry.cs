using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker
{
    public class NodeRegistry
    {
        public Dictionary<string, Node> registry;

        public NodeRegistry()
        {
            Console.WriteLine("[NodeRegistry] has been initialized");
            this.registry = new Dictionary<string, Node>();
        }
        public async Task<bool> Register(Node node)
        {
            this.registry.Add(node.Identifier, node);
            return await Task.FromResult(true);
        }
    }
}
