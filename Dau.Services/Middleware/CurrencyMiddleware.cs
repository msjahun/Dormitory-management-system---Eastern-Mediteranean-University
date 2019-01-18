using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Dau.Services.Middleware
{
   public class CurrencyMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            var CurrencyQuery = context.Request.Query["currency"];
            if (!string.IsNullOrWhiteSpace(CurrencyQuery))
            {
                var culture = new CultureInfo(CurrencyQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;


                context.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            }



            await next(context);
        }

    }
}
