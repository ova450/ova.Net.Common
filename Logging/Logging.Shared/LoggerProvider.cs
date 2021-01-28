using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace ova.Common.Logging.Shared
{
    public abstract partial class LoggerProvider :  ILoggerProvider
    {
        public LoggerProvider() { }

        readonly ConcurrentDictionary<string, Logger> loggers = new ConcurrentDictionary<string, Logger>();

        ILogger ILoggerProvider.CreateLogger(string Category)
        { return loggers.GetOrAdd(Category, (category) => { return new Logger(this, category); }); }

        public abstract bool IsEnabled(LogLevel logLevel);

        public abstract void WriteLog(LogEntry Info);
    }
}