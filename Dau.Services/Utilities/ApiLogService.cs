using Dau.Core.Domain;
using Dau.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dau.Services.Utilities
{
   public class ApiLogService : IApiLogService
    {
        private readonly IRepository<ApiDebugLog> _apiDebugLogRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiLogService(IRepository<ApiDebugLog> apiDebugLogRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiDebugLogRepository = apiDebugLogRepository;
        }

        public void LogApiRequest (ApiDebugLog apiDebugLog)
        {

            _apiDebugLogRepository.Insert(apiDebugLog);

        }


        public List<ApiDebugLog> getApiDebugLogs()
        {
            return _apiDebugLogRepository.List().OrderByDescending(x => x.Id).ToList();
        }

        public void DeleteEntries()
        {
          var logs=  _apiDebugLogRepository.List().OrderByDescending(x => x.Id).ToList();

            foreach (var log in logs)
            {
                _apiDebugLogRepository.Delete(log);
            }
        }

        public string GetRequestBody()
        {
            var bodyStr = "";
            var req = _httpContextAccessor.HttpContext.Request;

            // Allows using several time the stream in ASP.Net Core
            req.EnableRewind();

            // Arguments: Stream, Encoding, detect encoding, buffer size 
            // AND, the most important: keep stream opened
            using (StreamReader reader
                      = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }


            return bodyStr;
        }

    }
}
