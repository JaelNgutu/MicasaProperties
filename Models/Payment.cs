using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        public int Amount { get; set; }

        public int Date { get; set; }

        public int TenantID { get; set; }

         public Tenant Tenant { get; set; }

}
}
