using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareAppWebAPI.Models
{
    public class AppUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string DateOfRegistration { get; set; }
    }
}
