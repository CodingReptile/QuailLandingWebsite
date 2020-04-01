using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuailLandingWebsite.Models
{
    public class QuailLandingHome
    {
        public int Id { get; set; }

        /// <summary>
        /// The house number
        /// </summary>
        [Required]
        public int HomeNumber { get; set; }

        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Owner information 
        /// </summary>
        public Owner Owner { get; set; }
    }
}
