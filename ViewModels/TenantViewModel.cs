using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MicasaProperties.Data;
using MicasaProperties.Models;

namespace MicasaProperties.ViewModels
{
    public class TenantViewModel
    {

        public Tenant Tenant { get; set; }

        public Building Building { get; set; }

        public IEnumerable<Payment> payments { get; set; }

    }
}
