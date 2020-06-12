using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace monolith
{
    internal class ManagedNode
    {
        private Program.Options o;

        public ManagedNode(Program.Options o)
        {
            this.o = o;
        }
        public async Task Run() {
            // The port number(5001) must match the port of the gRPC server.
            try {
                Console.WriteLine($"https://{ o.Host }:${ o.Port }");
                var channelOptions = new GrpcChannelOptions {
                    // Credentials = Grpc.Core.ChannelCredentials.Insecure, // Grpc.Core.ChannelCredentials.Create(Grpc.Core.ChannelCredentials.Insecure, Grpc.Core.CallCredentials.FromInterceptor())
                };
                using var channel = GrpcChannel.ForAddress($"https://{ o.Host }:{ o.Port }", channelOptions);
                
                var nodeRegistryClient = new NodeRegistry.NodeRegistryClient(channel);
                var fileRegistryClient = new FileRegistry.FileRegistryClient(channel);
                { // Auth
                    var reply = await nodeRegistryClient.AuthenticateAsync(
                                new NodeAuthenticationRequest { Identifier = o.ClientID });
                    Console.WriteLine($"Authentication as { o.ClientID }: " + reply.Status);
                }
                bool gracefulDisconnect = false;
                do { // Main Loop
                    try {
                        var command = Console.ReadLine();
                        var args = command.Split(' ');

                        switch (command.IndexOf(' ') > -1 ? args[0] : command) {
                            case "exit": gracefulDisconnect = true; break;
                            case "register": if (args.Length == 2) {
                                var fileName = args[1];
                                var reply = await fileRegistryClient.RegisterAsync(
                                    new FileRegisterRequest { Filename = fileName });
                            } break;
                            case "browse": {
                                var reply = await fileRegistryClient.BrowseAsync(
                                    new FileBrowseRequest { });
                                foreach(var fileName in reply.Filenames)
                                    Console.WriteLine(fileName);
                            } break;

                        }
                    } catch (Exception e) {
                        Console.WriteLine(e);
                    }
                } while (!gracefulDisconnect);

                Console.WriteLine("Press any key to exit...");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}