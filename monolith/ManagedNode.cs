using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace monolith
{
    internal class ManagedNode
    {
        private Program.Options o;
        private ServiceCollection services { get; }
        private ILoggerFactory logger { get; }
        public ManagedNode(Program.Options o)
        {
            this.o = o;
            this.services = new ServiceCollection();
            this.logger = LoggerFactory.Create(logging =>
            {
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.None);
            });
        }

        public async Task Run()
        {
            Uri Address = new Uri($"https://{ o.Host }:{ o.Port }");
            services.AddGrpcClient<NodeRegistry.NodeRegistryClient>(o =>
            {
                o.Address = Address;
            });
            services.AddGrpcClient<FileRegistry.FileRegistryClient>(o =>
            {
                o.Address = Address;
            });
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var provider = serviceProvider;
            // The port number(5001) must match the port of the gRPC server.
            try
            {
                Console.WriteLine(Address);
                { // Auth
                    var reply = await provider.GetRequiredService<NodeRegistry.NodeRegistryClient>().AuthenticateAsync(
                                new NodeAuthenticationRequest { Identifier = o.ClientID });
                    Console.WriteLine($"Authentication as { o.ClientID }: " + reply.Status);
                }
                { // Auth Check
                    var reply = await provider.GetRequiredService<NodeRegistry.NodeRegistryClient>().TestAsync(new NodeTestRequest { Identifier = o.ClientID });
                    Console.WriteLine($"Authentication Test as { o.ClientID }: " + reply.Status);
                    if (reply.Status == false) {
                        Console.WriteLine("Something fucked up wrongly");
                        return;
                    }
                }
                bool gracefulDisconnect = false;
                do
                { // Main Loop
                    try
                    {
                        var command = Console.ReadLine();
                        var args = command.Split(' ');

                        switch (command.IndexOf(' ') > -1 ? args[0] : command)
                        {
                            case "exit": gracefulDisconnect = true; break;
                            case "register":
                                if (args.Length == 2)
                                {
                                    var fileName = args[1];
                                    var reply = await provider.GetRequiredService<FileRegistry.FileRegistryClient>().RegisterAsync(
                                        new FileRegisterRequest { Filename = fileName });
                                    Console.WriteLine($"{ reply.Id }");
                                }
                                break;
                            case "browse":
                                {
                                    var reply = await provider.GetRequiredService<FileRegistry.FileRegistryClient>().BrowseAsync(
                                        new FileBrowseRequest { });
                                    foreach (var file in reply.Files)
                                        Console.WriteLine(file);
                                }
                                break;
                            case "get":
                                if (args.Length == 2)
                                {
                                    var id = args[1];
                                    var reply = await provider.GetRequiredService<FileRegistry.FileRegistryClient>().GetAsync(
                                        new FileGetRequest { Id = id });
                                    foreach (var fileName in reply.Where2Get)
                                        Console.WriteLine($"{ fileName }");
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                } while (!gracefulDisconnect);

                Console.WriteLine("Press any key to exit...");
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}