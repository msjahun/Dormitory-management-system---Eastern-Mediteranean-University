using Dau.Core.Domain.Logging;
using Dau.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Services.Logging
{
    class DBLogger:ILogger
    {
        private string _categoryName;
        //private Func<string, LogLevel, bool> _filter;
        // private SqlHelper _helper;

        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();
        private int MessageMaxLength = 4000;
        private readonly object _accessor;

        public DBLogger(string categoryName)
        {
            _categoryName = categoryName;
            //_filter = filter;
         //  _helper = new SqlHelper(connectionString);
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            if (exception != null)
            {
                message += "\n" + exception.ToString();
            }
            message = message.Length > MessageMaxLength ? message.Substring(0, MessageMaxLength) : message;
            Log eventLog = new Log
            {
                Message = message,
                EventId = eventId.Id,
                LogLevel = logLevel.ToString(),
              //put ip address and begin logging ipAddress and user actions here, it's totally ethical
                CreatedTime = DateTime.UtcNow
            };
            //  _helper.InsertLog(eventLog);
            _context.Log.Add(eventLog);
            _context.SaveChangesAsync();
        }



        public bool IsEnabled(LogLevel logLevel)
        {
            //   return (_filter == null || _filter(_categoryName, logLevel));
            return true;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
