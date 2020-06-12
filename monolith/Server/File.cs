using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Server {
    public class File {
        public string Filename { get; set; }

        public File(string Filename) { 
            this.Filename = Filename;
        }

    }
}
