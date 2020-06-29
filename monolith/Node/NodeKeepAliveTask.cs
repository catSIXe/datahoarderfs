using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

namespace monolith.Node
{
    public class NodeKeepAliveTask
    {
        // private readonly ILogger<NodeKeepAliveTask> _logger;
        private monolith.NodeRegistry.NodeRegistryClient nodeRegistryClient { get; }

        public NodeKeepAliveTask(
            NodeRegistry.NodeRegistryClient nodeRegistryClient //, 
            // ILogger<NodeKeepAliveTask> logger
        ) {
            // _logger = logger;
            this.nodeRegistryClient = nodeRegistryClient;
        }
        public Task Start(int seconds) {
            return Task.Run(async() => {
                do {
                    await Task.Delay(TimeSpan.FromSeconds(seconds));
                    await this.SendKeepAlive();
                } while (true);
            });
        }
        public async Task<monolith.NodeUpdateStreamReply> SendKeepAlive() {
            //Console.WriteLine("Sent keepAlive");
            return await this.nodeRegistryClient.UpdateStreamAsync(new NodeUpdateStreamRequest {
            });
        }
    }
}
