using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class FileVersion {
        public Guid Id { get; set; }
        public Guid File { get; set; }
        public DateTime Date { get; set; }
    }
}
