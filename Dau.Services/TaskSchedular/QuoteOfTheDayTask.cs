using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dau.Services.TaskSchedular.Scheduling;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dau.Services.TaskSchedular
{
    // uses https://theysaidso.com/api/
    public class QuoteOfTheDayTask : IScheduledTask
    {
        public string Schedule => "*/1 * * * *";
        
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            //var httpClient = new HttpClient();

            //var quoteJson = JObject.Parse(await httpClient.GetStringAsync("http://quotes.rest/qod.json"));

            //QuoteOfTheDay.Current = JsonConvert.DeserializeObject<QuoteOfTheDay>(quoteJson["contents"]["quotes"][0].ToString());
            //QuoteOfTheDay.Current.Quote = QuoteOfTheDay.Current.Quote + " " + DateTime.Now;
            QuoteOfTheDay.Current = new QuoteOfTheDay { Quote = "Hello world " + DateTime.Now, Author = "musa jahun" };
        }
    }
    
    public class QuoteOfTheDay
    {
        public static QuoteOfTheDay Current { get; set; }

        static QuoteOfTheDay()
        {
            Current = new QuoteOfTheDay { Quote = "No quote", Author = "Maarten" };
        }
        
        public string Quote { get; set; }
        public string Author { get; set; }
    }
}