using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class FileChunk {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public int Order { get; set; }
        public int Size { get; set; }
    }
}
