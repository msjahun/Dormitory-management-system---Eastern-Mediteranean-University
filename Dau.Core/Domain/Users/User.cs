using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
namespace Dau.Core.Domain.Users
{
    public class User : IdentityUser
    {
      

     
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string StudentNumber { get; set; }
        public string ParmanentAddress { get; set; }

        /// <summary>
        /// Gets or sets the affiliate identifier
        /// </summary>
        public long AffiliateId { get; set; }
        public string UserImageUrl { get; set; }//Image photo url
        /// <summary>
        /// Gets or sets the Dormitory identifier with which this customer is associated (manager)
        /// </summary>
        public long DormitoryId { get; set; }


        public string AdminComment { get; set; }
        public bool NewsletterSubscription { get; set; }
        public bool Active { get; set; }

        public bool Deleted { get; set; }


        /// <summary>
        /// Gets or sets the last IP address
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last login
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last activity
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

         
             

     
    }
}
