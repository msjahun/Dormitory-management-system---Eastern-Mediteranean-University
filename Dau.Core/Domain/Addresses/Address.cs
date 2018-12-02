using System;
using System.Collections.Generic;
using System.Text;
using Dau.Core.Domain.Reservations;
namespace Dau.Core.Domain.Addresses
{
   public class Address : BaseEntity
    {
        public Address()
        {
            Reservations = new HashSet<Reservation>();
        }

        //public string FullName { get; set; }
        //public string Email { get; set; }
        //public string PhoneNumber { get; set; }
        //needs an Id
        //Do we needs things above ^ since there will be in the user table, not atomic\\

        
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateProvinceId { get; set; }
        public string ZipPostalCode { get; set; }
        public int CountryId { get; set; }

        //a lot of the entities will use address
        //relationship with countryId and stateProvinceId
        public ICollection<Reservation> Reservations{ get; set; }
    }
}
