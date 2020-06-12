using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Server {
    public class NodeRegistry {
        public Dictionary<string, Node> registry;


        private static NodeRegistry instance = null;
        private static readonly object padlock = new object();
        public static NodeRegistry Instance {
            get {
                lock (padlock) {
                    if (instance == null) instance = new NodeRegistry();
                    return instance;
                }
            }
        }
        public NodeRegistry() {
            Console.WriteLine("[NodeRegistry] has been initialized");
            this.registry = new Dictionary<string, Node>();
        }
        public async Task<bool> Register(Node node) {
            this.registry.Add(node.Identifier, node);
            return true;
        }
    }
}
