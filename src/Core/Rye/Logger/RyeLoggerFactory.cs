﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rye.Logger
{
    public class RyeLoggerFactory : ILoggerFactory
    {
        private readonly RyeLoggerProvider _provider = new RyeLoggerProvider();

        public void AddProvider(ILoggerProvider provider)
        {
            LogRecord.Debug(nameof(RyeLoggerFactory), "AddProvider will be ignored");
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _provider.CreateLogger(categoryName);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _provider?.Dispose();
            }
        }
    }
}
