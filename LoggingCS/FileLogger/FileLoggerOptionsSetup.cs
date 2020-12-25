using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace ova.Common.Logging.FileLogger
{
    internal class FileLoggerOptionsSetup : ConfigureFromConfigurationOptions<FileLoggerOptions>
    {
        public FileLoggerOptionsSetup(ILoggerProviderConfiguration<FileLoggerProvider>providerConfiguration): base(providerConfiguration.Configuration) { }
    }
}
