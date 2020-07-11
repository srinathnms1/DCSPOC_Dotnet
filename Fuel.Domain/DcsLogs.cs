namespace Fuel.Domain
{
    using System;

    public class DcsLogs
    {
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public int? Level { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Exception { get; set; }
        public string LogEvent { get; set; }
    }
}
