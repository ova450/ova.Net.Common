using System.Collections.Generic;

namespace ova.Common.Logging.Shared
{
  public class LogScopeInfo 
    {
        public string Text { get; set; }
        public IDictionary<string, object> Properties { get; set; }
    }
}
