using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class File {
        public Guid Id { get; set; }
        public Guid ContainerID { get; set; }
        public string Filename { get; set; }
        public string Owner { get; set; }
    }
}
