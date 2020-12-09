﻿using Microsoft.Extensions.Logging;
using System;

namespace ova.eCoin.Infrastructure.Service.Logging
{

    //public interface ILoggerProvider : IDisposable { ILogger CreateLogger(string categoryName); }

    public class FileLoggerProvider : ILoggerProvider
    {
        private string _path;

        public FileLoggerProvider(string path) { _path = path; }

        public ILogger CreateLogger(string categoryName) { return new FileLogger(_path); }

        public void Dispose() { }
    }
}
 
