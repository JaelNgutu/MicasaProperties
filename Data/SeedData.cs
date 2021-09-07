using MicasaProperties.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicasaProperties.Data
{
    public class SeedData
    {

        //accessing database

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MicasaContext(serviceProvider.GetRequiredService<DbContextOptions<MicasaContext>>()))
            {
                if (context.Buildings.Any())
                {
                    return;
                }

                context.Buildings.AddRange(
                    new Building
                    {
                        BuildingName = "MaisonApartments",
                        UnitsAvailable = 15,
                        CostPerUnit = 500

                    },
                    new Building
                    {
                        BuildingName = "HeimApartments",
                        UnitsAvailable = 14,
                        CostPerUnit = 400

                    }
                );

                context.SaveChanges();
            }
        }

    }
}
