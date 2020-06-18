using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker
{
    public class NodeInactivityCleaner
    {
        private NodeRegistry nodeRegistry { get; }

        public NodeInactivityCleaner(
            NodeRegistry nodeRegistry //, 
        ) {
            this.nodeRegistry = nodeRegistry;
        }
        public Task Start() {
            return Task.Run(async() => {
                do {
                    await Task.Delay(TimeSpan.FromSeconds(30));
                    await this.nodeRegistry.CollectGarbage();
                } while (true);
            });
        }
    }
}
