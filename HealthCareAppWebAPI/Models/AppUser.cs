using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareAppWebAPI.Models
{
    public class AppUser
    {
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Pasword { get; set; }

        public string IsAdmin { get; set; }

        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
