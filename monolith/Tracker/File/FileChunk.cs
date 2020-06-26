using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class FileChunk {
        public Guid Id { get; set; }
        public Guid File { get; set; }
        public int OrderId { get; set; }
        public int Size { get; set; }
    }
}
