using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class Container {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
    }
}
