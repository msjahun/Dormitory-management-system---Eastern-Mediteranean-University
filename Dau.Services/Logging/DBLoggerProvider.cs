using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Logging
{
   public class DBLoggerProvider: ILoggerProvider
    {
       // private readonly Func<string, LogLevel, bool> _filter;
       // private string _connectionString;
        public DBLoggerProvider()
        {
            //inject dbLogger here
           // _filter = filter;
           // _connectionString = connectionStr;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DBLogger(categoryName);
        // return new DBLogger();
        }
        public void Dispose()
        {
        }
    }
}
