using System;
using System.Collections.Generic;

namespace Fuel.Infrastructure.Models
{
    public partial class DcsLogs1
    {
        public int Id { get; set; }
        public string Application { get; set; }
        public string Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}
