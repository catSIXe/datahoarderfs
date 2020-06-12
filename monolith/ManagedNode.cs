using Grpc.Net.Client;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace monolith
{
    internal class ManagedNode
    {
        private Program.Options o;

        public ManagedNode(Program.Options o)
        {
            this.o = o;
        }
        public async Task Run()
        {
            // The port number(5001) must match the port of the gRPC server.
            try
            {
                Console.WriteLine($"https://{ o.Host }:${ o.Port }");
                var channelOptions = new GrpcChannelOptions
                {
                    // preparing for auth-stuff
                    // Credentials = Grpc.Core.ChannelCredentials.Insecure, // Grpc.Core.ChannelCredentials.Create(Grpc.Core.ChannelCredentials.Insecure, Grpc.Core.CallCredentials.FromInterceptor())

                    // HttpHandler = new ApiKeyHandler("MY_KEY"),
                };
                using var channel = GrpcChannel.ForAddress($"https://{ o.Host }:{ o.Port }", channelOptions);

                var nodeRegistryClient = new NodeRegistry.NodeRegistryClient(channel);
                var fileRegistryClient = new FileRegistry.FileRegistryClient(channel);
                { // Auth
                    var reply = await nodeRegistryClient.AuthenticateAsync(
                                new NodeAuthenticationRequest { Identifier = o.ClientID });
                    Console.WriteLine($"Authentication as { o.ClientID }: " + reply.Status);
                }
                {
                    var reply = await nodeRegistryClient.TestAsync(new NodeTestRequest { Identifier = o.ClientID });
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
                                    var reply = await fileRegistryClient.RegisterAsync(
                                        new FileRegisterRequest { Filename = fileName });
                                    Console.WriteLine($"{ reply.Id }");
                                }
                                break;
                            case "browse":
                                {
                                    var reply = await fileRegistryClient.BrowseAsync(
                                        new FileBrowseRequest { });
                                    foreach (var file in reply.Files)
                                        Console.WriteLine(file);
                                }
                                break;
                            case "get":
                                if (args.Length == 2)
                                {
                                    var id = args[1];
                                    var reply = await fileRegistryClient.GetAsync(
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