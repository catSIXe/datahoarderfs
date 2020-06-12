using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Server {
    public class FileRegistry {
        public Dictionary<string, File> registry;

        private static FileRegistry instance = null;
        private static readonly object padlock = new object();
        public static FileRegistry Instance {
            get {
                lock (padlock) {
                    if (instance == null) instance = new FileRegistry();
                    return instance;
                }
            }
        }
        public FileRegistry() {
            Console.WriteLine("[FileRegistry] has been initialized");
            this.registry = new Dictionary<string, File>();
        }
        public async Task<bool> Register(File file) {
            this.registry.Add(file.Filename, file);
            return true;
        }
        public async Task<File[]> Browse() {
            File[] files = new File[this.registry.Count];
            this.registry.Values.CopyTo(files, 0);
            return files;
        }
    }
}
