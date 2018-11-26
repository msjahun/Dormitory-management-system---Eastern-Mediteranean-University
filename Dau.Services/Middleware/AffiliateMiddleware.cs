using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dau.Services.Middleware
{
    public class AffiliateMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var keyValue = context.Request.Query["AffiliateId"];

            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                var affiliateId = keyValue;

                //take the affiliateId and associate the user with the affiliate account

                /* _db.Add(new Request()
                 {
                     DT = DateTime.UtcNow,
                     MiddlewareActivation = "FactoryActivatedMiddleware",
                     Value = keyValue
                 });*/

                //   await _db.SaveChangesAsync();
            }

            await next(context);
        }
    }
}
