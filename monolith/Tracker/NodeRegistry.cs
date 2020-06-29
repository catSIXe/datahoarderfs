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
        public async Task CollectGarbage() {
            foreach (var node in from node in this.registry.Values
                                 where DateTime.Now.Subtract(node.lastActivity).TotalMinutes >= 1
                                 select node)
            {
                Console.WriteLine($"[NodeRegistry] cleaned { node.Identifier  }");
                this.registry.Remove(node.Identifier);
            }
            await Task.FromResult(true); // make compiler happy
        }
        public async Task<Node> Get(string nodeIdentifier) {
            await Task.FromResult(true); // make compiler happy
            return this.registry[nodeIdentifier];
        }
    }
}
