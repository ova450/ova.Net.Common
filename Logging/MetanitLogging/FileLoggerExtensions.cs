using Microsoft.Extensions.Logging;

namespace ova.eCoin.Infrastructure.Service.Logging.Metanit
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string filePath)
        {
            factory.AddProvider(new FileLoggerProvider(filePath));
            return factory;
        }
    }
}

 
