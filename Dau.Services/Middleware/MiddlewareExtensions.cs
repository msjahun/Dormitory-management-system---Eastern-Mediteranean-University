using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Dau.Services.Middleware
{
   public static class MiddlewareExtensions
    {

       //factorybased middleware

        public static IApplicationBuilder UseOnlineUsersMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OnlineUsersMiddleware>();
        }

        public static IApplicationBuilder UseAffiliatesMiddleware(
          this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AffiliateMiddleware>();
        }
    }
}
