using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuailLandingWebsite.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
