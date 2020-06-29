using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace monolith.Tracker {
    public class Version {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public DateTime Date { get; set; }
        public long Size { get; set; }
    }
}
