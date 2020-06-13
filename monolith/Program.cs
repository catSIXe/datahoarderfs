using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using CommandLine;
using System.Threading;

namespace monolith {
    public class Program {
        public class Options {
            [Option('m', "mode", Required = true, HelpText = "Start as a node/tracker")] public string Mode { get; set; }

            [Option('h', "host", Required = false, HelpText = "Where should the Node connect to")] public string Host { get; set; } = "localhost";

            [Option('p', "port", Required = false, HelpText = "Which Port to use")] public int Port { get; set; } = 5001;

            [Option("id", Required = false, HelpText = "Which ClientID to use as authentication")] public string ClientID { get; set; } = "client";
            
        }

        public static async Task Main(string[] args) {
            await Parser.Default.ParseArguments<Options>(args)
            .WithParsedAsync<Options>(async o => {
                Console.WriteLine("[CParser] Running as {0}", o.Mode);
                switch (o.Mode.ToLower()) {
                    case "tracker":
                        CreateHostBuilder(args).Build().Run();
                    break;
                    case "node":
                        var node = new ManagedNode(o);
                        await node.Run();
                    break;
                }
                Console.WriteLine("exited");
            });
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
