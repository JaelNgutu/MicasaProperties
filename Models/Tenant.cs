using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Models
{
    public class Tenant
    {
        public int TenantID { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Max length is 50")]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }

        public int BuildingID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode= true)]
        public DateTime? DateMoveIn { get; set; }

        public DateTime? DateMoveOut { get; set; }

        public Building Building { get; set; }

        public ICollection<Payment> Payments { get; set; }



    }
}
