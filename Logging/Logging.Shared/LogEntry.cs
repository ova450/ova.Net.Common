using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ova.Common.Logging.Shared
{
   public class LogEntry 
    {
        public LogEntry()
        {
            TimeStamp =UnixTime.Base.Timestamp();
            UserName = Environment.UserName;
        }

        static public readonly string StaticHostName = System.Net.Dns.GetHostName();
        public string UserName { get; private set; }
        public string HostName { get { return StaticHostName; } }

        public long TimeStamp { get; private set; }
        public string Category { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public EventId EventId { get; set; }
        public object State { get; set; }
        public string StateText { get; set; }
        public Dictionary<string, object> StateProperties { get; set; }
        public IList<LogScopeInfo> Scopes { get; set; }
        //IList<ILogScopeInfo> ILogEntry.Scopes { get; set; }
    }
}
