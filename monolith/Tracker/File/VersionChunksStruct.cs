using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class VersionChunksStruct {
        public Guid FileVersionID { get; set; }
        public Guid ChunkID { get; set; }
    }
}
