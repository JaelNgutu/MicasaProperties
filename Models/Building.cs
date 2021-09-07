using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Models
{
    public class Building
    {
        public int BuildingID { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Max length is 50")]
        public string BuildingName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter units available")]
        public int UnitsAvailable { get; set; }

        [Required, Range(0, 999.99, ErrorMessage = "Maximum cost is 999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPerUnit { get; set; }


     
        public decimal ExpectedRevenue
        {
            get => UnitsAvailable * CostPerUnit;
            set => value = UnitsAvailable * CostPerUnit  ;
        }



    }
}
