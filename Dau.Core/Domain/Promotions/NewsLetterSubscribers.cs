using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Promotions
{
    class NewsLetterSubscribers
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Email { get; set; }

        public int Active { get; set; }

        public int CustomerRoles { get; set; }
    }
}
