using MicasaProperties.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Data
{
    public class MicasaContext : IdentityDbContext<AppUser>
    {

        public MicasaContext(DbContextOptions<MicasaContext> options)
           : base(options)

        {
        }

        public DbSet<Building> Buildings { get; set; }

            public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Payment> Payments { get; set; }

    }
}
