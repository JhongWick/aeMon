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
    public class UserRoles
    {
        public static void Seed(DataAccessLayer.DBContext context)
        {
            
            if (context.UserRoles.Count() <= 0)
            {
                context.UserRoles.Add(new UserRole { UserId = 1, RoleId = 3 , IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 2, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 3, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 4, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 5, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 6, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 7, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 8, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 9, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 10, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 11, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 12, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 13, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 14, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 15, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 16, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 17, RoleId = 3, IsDeleted = false });
                context.UserRoles.Add(new UserRole { UserId = 18, RoleId = 2, IsDeleted = false });


            }
            context.SaveChanges();
        }
    }
}
