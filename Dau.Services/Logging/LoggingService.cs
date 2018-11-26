using Dau.Core.Domain.Logging;
using Dau.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Logging
{
   public class LoggingService : ILoggingService
    {
        private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();



        public List<Log> GetLogs()
        {
            var Logs = new List<Log>();
            _context.Log.OrderByDescending(d=> d.CreatedTime).ToList().ForEach(p =>
            {
                Logs.Add(new Log
                {
                    Message = p.Message,
                    LogLevel = p.LogLevel,
                    CreatedTime = p.CreatedTime,
                    Id = p.Id,
                    EventId = p.EventId
                });
            });

            return Logs;
        }



        public Log GetLogById(int Id)
        {
            var log = new Log();

         log=    _context.Log.Where(l => l.Id == Id).FirstOrDefault();

            return log;
        }



        public bool DeleteLogById(int Id)
        {
            var LogToRemove = _context.Log.SingleOrDefault(x => x.Id == Id);
            _context.Log.Remove(LogToRemove);
            _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteAllLogs()
        {
            var all = _context.Log;
            _context.Log.RemoveRange(all);
            _context.SaveChangesAsync();
            return true;
        }

    }

   
}
