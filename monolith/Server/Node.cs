using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Server {
    public class Node {
        public string Identifier { get; set; }

        public DateTime lastActivity { get; set; }
        public Node(string Identifier) { 
            this.Identifier = Identifier;
            this.lastActivity = DateTime.Now;
        }

    }
}
