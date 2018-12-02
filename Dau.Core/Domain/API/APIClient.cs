using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.API
{
   public class APIClient : BaseEntity

    {
      
       public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUrl { get; set; }

       public int AccessTokenLifeTime { get; set; }

        public int RefreshTokenLifetime { get; set; }

         public bool Enabled { get; set; }

      

    }
}
