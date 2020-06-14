using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;

namespace monolith
{
    public class NodeRegistryService : NodeRegistry.NodeRegistryBase
    {
        private readonly ILogger<NodeRegistryService> _logger;
        private monolith.Tracker.FileRegistry fileRegistry { get; }
        private monolith.Tracker.NodeRegistry nodeRegistry { get; }

        public NodeRegistryService(
            monolith.Tracker.NodeRegistry nodeRegistry, 
            ILogger<NodeRegistryService> logger
        ) {
            _logger = logger;
            this.fileRegistry = fileRegistry;
            this.nodeRegistry = nodeRegistry;
        }

        public async override Task<NodeAuthenticationReply> Authenticate(NodeAuthenticationRequest request, ServerCallContext context) {
            Tracker.Node node = new Tracker.Node(request.Identifier);
            await this.nodeRegistry.Register(node);
            _logger.LogInformation($"Node Connected { request.Identifier }");
            // context.UserState["UserId"] = request.Identifier;

            var httpContext = context.GetHttpContext();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Identifier),
                new Claim(ClaimTypes.Role, "Node"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                }
            );

            return (await Task.FromResult(new NodeAuthenticationReply {
                Status = true
            }));
        }

        public async override Task<NodeTestReply> Test(NodeTestRequest request, ServerCallContext context) {
            return (await Task.FromResult(new NodeTestReply {
                Status = request.Identifier == context.GetHttpContext().User.Identity.Name
            }));
        }
    }
}
