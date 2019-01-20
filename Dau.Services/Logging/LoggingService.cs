using Dau.Core.Domain.Logging;
using Dau.Data;
using Dau.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dau.Services.Logging
{
   public class LoggingService : ILoggingService
    {
       // private Fees_and_facilitiesContext _context = new Fees_and_facilitiesContext();
        private IRepository<Log> _logRepository;

        public LoggingService(IRepository<Log> LogRepository)
        {
            _logRepository = LogRepository;
        }

        public IOrderedEnumerable<Log> GetLogs()
        {
          var Logs= _logRepository.List().OrderByDescending(d => d.CreatedTime);
         
            return Logs;
        }



        public Log GetLogById(int Id)
        {
            var log = new Log();

            log = _logRepository.GetById(Id);
            return log;
        }



        public bool DeleteLogById(int Id)
        {
            var LogToRemove = _logRepository.GetById(Id);
            _logRepository.Delete(LogToRemove);
           
            return true;
        }

        public bool DeleteAllLogs()
        {
            var all = _logRepository.List();
            foreach(var log in all){
             _logRepository.Delete(log);
            }
           
            return true;
        }

        public object GetEventLogs()
        {
            throw new NotImplementedException();
        }
    }

   
}
