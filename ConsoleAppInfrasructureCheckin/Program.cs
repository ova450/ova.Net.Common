using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ova.Common.Logging.Entry;
using ova.Common.Logging.FileLogger;
using System;
using static ova.Common.Hosting.ConfigurationByHost;

namespace ova.eCoin.Testing.ConsoleAppInfrasructureCheckin
{
    class Program
    {
        static void Main(string[] args)
        {
            HostInitAsync(args);
        }

        public static async void HostInitAsync(string[] args)
        {
            //LogService log;// = new LogService();
            using IHost host = CreateHostBuilder(args).Build();
            {
                Console.WriteLine($"---------------------------- begin -------------------------------");
                await host.StartAsync();
                Console.WriteLine($"---------------------------- after startasync, filelogger preparation -------------------------------");
                FileLoggerOptions options = new FileLoggerOptions();
                FileLoggerProvider filelogger = new FileLoggerProvider(options);
                LogEntry info = new LogEntry();
                info.Category = "ConsoleAppInfrasructureCheckin.Program"; //ova.eCoin.Testing.
                info.Level = LogLevel.Trace;
                info.Text = "запись в файллоггер";
                filelogger.WriteLog(info);
                filelogger.LogTrace("ConsoleAppInfrasructureCheckin.Program", "уровень 0 trace");
                filelogger.LogDebug("ConsoleAppInfrasructureCheckin.Program", "уровень 1 Debug");
                filelogger.LogInfo("ConsoleAppInfrasructureCheckin.Program", "уровень 2 Info");
                filelogger.LogWarning("ConsoleAppInfrasructureCheckin.Program", "уровень 3 Warning");
                filelogger.LogError("ConsoleAppInfrasructureCheckin.Program", "уровень 4 Error");
                filelogger.LogCritical("ConsoleAppInfrasructureCheckin.Program", "уровень 5 Critical");
                filelogger.LogNone("ConsoleAppInfrasructureCheckin.Program", "уровень 6 None");
                Console.WriteLine($"---------------------------- befor stopasync, filelogger worked -------------------------------");
                Console.ReadKey();
                await host.StopAsync();
                Console.WriteLine($"---------------------------- after stopasync -------------------------------");
                Console.ReadKey();
            }
        }
    }
}