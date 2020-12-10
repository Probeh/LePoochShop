using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Shared.Helpers
{
    public class LoggingEventArgs : EventArgs
    {
        // ======================================= //
        public DateTime Created { get; set; }
        public string Target { get; set; }
        public string Method { get; set; }
        public string Summary { get; set; }
        public KeyValuePair<string, IConvertible> Payloads { get; set; }
        // ======================================= //
        public LoggingEventArgs() => this.Created = DateTime.Now;
        // ======================================= //
        public LoggingEventArgs(string target, string method, string summary, KeyValuePair<string, IConvertible> values) : this()
        {
            this.Target = target;
            this.Method = method;
            this.Summary = summary;
            this.Payloads = values;
        }
    }
}