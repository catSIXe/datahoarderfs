using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class Node {
        public string Identifier { get; set; }

        public DateTime lastActivity { get; set; }
        public Node(string Identifier) { 
            this.Identifier = Identifier;
            this.lastActivity = DateTime.Now;
        }
        public void MarkActivity() {
            this.lastActivity = DateTime.Now;
            Console.WriteLine($"{ this.Identifier } lastActivity { this.lastActivity }");
        }
    }
}
