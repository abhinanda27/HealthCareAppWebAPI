using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareAppWebAPI.Models
{
    public class Cart
    {
        public int MedicineID { get; set; }

        public string MedicineName { get; set; }

        public float MedicinePrice { get; set; }
    }
}
