using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.API
{
   public class APIClient
    {
       public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string REdirectUrl { get; set; }

       public int AccessToikenLifeTime { get; set; }

        public int RefreshTokenLifetime { get; set; }

         public bool Enabled { get; set; }

      

    }
}
