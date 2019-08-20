using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Migrations.Seeds
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public class Regions
    {
        public static void Seed(DataAccessLayer.DBContext context)
        {
           
            if (context.Regions.Count() <= 0)
            {
                context.Regions.Add(new Region { RegionId = 1, UniqueId = Guid.NewGuid(), Name = "Ilocos", Code = "I" });
                context.Regions.Add(new Region { RegionId = 2, UniqueId = Guid.NewGuid(), Name = "Cagayan Valley", Code = "II" });
                context.Regions.Add(new Region { RegionId = 3, UniqueId = Guid.NewGuid(), Name = "Central Luzon", Code = "III" });
                context.Regions.Add(new Region { RegionId = 4, UniqueId = Guid.NewGuid(), Name = "CALABARZON", Code = "IV-A" });
                context.Regions.Add(new Region { RegionId = 5, UniqueId = Guid.NewGuid(), Name = "MIMAROPA", Code = "IV-B" });
                context.Regions.Add(new Region { RegionId = 6, UniqueId = Guid.NewGuid(), Name = "Bicol", Code = "V" });
                context.Regions.Add(new Region { RegionId = 7, UniqueId = Guid.NewGuid(), Name = "Western Visayas", Code = "VI" });
                context.Regions.Add(new Region { RegionId = 8, UniqueId = Guid.NewGuid(), Name = "Central Visayas", Code = "VII" });
                context.Regions.Add(new Region { RegionId = 9, UniqueId = Guid.NewGuid(), Name = "Eastern Visayas", Code = "VIII" });
                context.Regions.Add(new Region { RegionId = 10, UniqueId = Guid.NewGuid(), Name = "Zamboanga Peninsula", Code = "IX" });
                context.Regions.Add(new Region { RegionId = 11, UniqueId = Guid.NewGuid(), Name = "Northern Mindanao", Code = "X" });
                context.Regions.Add(new Region { RegionId = 12, UniqueId = Guid.NewGuid(), Name = "Davao", Code = "XI" });
                context.Regions.Add(new Region { RegionId = 13, UniqueId = Guid.NewGuid(), Name = "SOCCSKSARGEN", Code = "XII" });
                context.Regions.Add(new Region { RegionId = 14, UniqueId = Guid.NewGuid(), Name = "Caraga", Code = "XIII" });
                context.Regions.Add(new Region { RegionId = 15, UniqueId = Guid.NewGuid(), Name = "National Capital Region", Code = "NCR" });
                context.Regions.Add(new Region { RegionId = 16, UniqueId = Guid.NewGuid(), Name = "Cordillera Administrative Region", Code = "CAR" });
                context.Regions.Add(new Region { RegionId = 17, UniqueId = Guid.NewGuid(), Name = "Autonomus Region in Muslim Mindanao", Code = "ARMM" });

                

            }
            context.SaveChanges();
        }
    }
}
