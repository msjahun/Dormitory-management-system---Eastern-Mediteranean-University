using System;
using System.Collections.Generic;
using System.Text;

namespace Dau.Core.Domain.Address
{
    class Address
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string Country { get; set; }

        //a lot of the entities will use address
    }
}
