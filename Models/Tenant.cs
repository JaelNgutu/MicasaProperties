using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Models
{
    public class Tenant
    {
        public int TenantID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool Occupying { get; set; }

        public int BuildingID { get; set; }

        public DateTime? DateMoveIn { get; set; }

        public DateTime? DateMoveOut { get; set; }

        public Building Building { get; set; }

        public ICollection<Payment> Payments { get; set; }



    }
}
