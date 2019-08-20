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
    public class Role
    {
        public static void Seed(DataAccessLayer.DBContext context)
        {
            
            if (context.Roles.Count() <= 0)
            {
                context.Roles.Add(new Entities.Role { Name = "Admin", UniqueId = Guid.NewGuid() });
                context.Roles.Add(new Entities.Role { Name = "System Admin", UniqueId = Guid.NewGuid() });
                context.Roles.Add(new Entities.Role { Name = "EndUser", UniqueId = Guid.NewGuid() });
                
            }
            context.SaveChanges();
        }
    }
}
