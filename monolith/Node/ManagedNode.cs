using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace monolith.Node
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
            using var channel = GrpcChannel.ForAddress(Address);

            services.AddSingleton(new NodeRegistry.NodeRegistryClient(channel));
            services.AddSingleton(new FileRegistry.FileRegistryClient(channel));
            services.AddSingleton(new ContainerRegistry.ContainerRegistryClient(channel));

            services.AddSingleton<NodeKeepAliveTask>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var provider = serviceProvider;
            try
            {
                Console.WriteLine(Address);
                { // Auth
                    var reply = await provider.GetRequiredService<NodeRegistry.NodeRegistryClient>().AuthenticateAsync(
                                new NodeAuthenticationRequest { Identifier = o.ClientID });
                    Console.WriteLine($"Authentication as { o.ClientID }: " + reply.Status);
                    provider.GetRequiredService<NodeKeepAliveTask>().Start(reply.KeepAliveInterval);
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
                        Console.Write(">");
                        var command = Console.ReadLine();
                        var args = command.Split(' ');

                        switch (command.IndexOf(' ') > -1 ? args[0] : command)
                        {
                            case "exit": gracefulDisconnect = true; break;
                            case "ct.register":
                                if (args.Length == 2)
                                {
                                    var containerName = args[1];
                                    var reply = await provider.GetRequiredService<ContainerRegistry.ContainerRegistryClient>().RegisterAsync(
                                        new ContainerRegisterRequest { Name = containerName });
                                    Console.WriteLine($"{ reply.Id }");
                                }
                                break;
                            case "ct.browse":
                                {
                                    var reply = await provider.GetRequiredService<ContainerRegistry.ContainerRegistryClient>().BrowseAsync(
                                        new ContainerBrowseRequest { });
                                    foreach (var container in reply.Containers)
                                        Console.WriteLine(container);
                                }
                                break;
                            case "file.register":
                                if (args.Length == 3)
                                {
                                    var containerID = args[1];
                                    var fileName = args[2];
                                    var reply = await provider.GetRequiredService<FileRegistry.FileRegistryClient>().RegisterAsync(
                                        new FileRegisterRequest { Container = containerID, Filename = fileName });
                                    Console.WriteLine($"{ reply.Id }");
                                }
                                break;
                            case "file.browse":
                                if (args.Length == 2)
                                {
                                    var containerID = args[1];
                                    var reply = await provider.GetRequiredService<FileRegistry.FileRegistryClient>().BrowseAsync(
                                        new FileBrowseRequest { Container = containerID });
                                    foreach (var file in reply.Files)
                                        Console.WriteLine(file);
                                }
                                break;
                            case "help": {
                                Console.WriteLine("ct.browse");
                                Console.WriteLine("ct.register <container name>");
                                Console.WriteLine("file.register <container id> <filename>");
                                Console.WriteLine("file.browse <container id>");

                            } break;
                            /*case "file.download":
                                if (args.Length == 2)
                                {
                                    var id = args[1];
                                    var reply = await provider.GetRequiredService<FileRegistry.FileRegistryClient>().GetAsync(
                                        new FileGetRequest { Id = id });
                                    foreach (var fileName in reply.Where2Get)
                                        Console.WriteLine($"{ fileName }");
                                }
                                break;*/
                        }
                    }
                    catch (Exception e) {
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