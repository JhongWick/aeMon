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
    public class Modules
    {
        public static void Seed(DataAccessLayer.DBContext context)
        {
           
            if (context.Modules.Count() <= 0)
            {
                context.Modules.Add(new Module { ModuleId = 1, UniqueId = Guid.NewGuid(), Name = "Home-Dashboard", ModuleController = "Home" , ModuleAction= "Dashboard", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 2, UniqueId = Guid.NewGuid(), Name = "modules-index", ModuleController = "modules", ModuleAction = "index", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 3, UniqueId = Guid.NewGuid(), Name = "UserRights-Update", ModuleController = "UserRights", ModuleAction = "Update", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 4, UniqueId = Guid.NewGuid(), Name = "Home-Login", ModuleController = "Home", ModuleAction = "Login", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 5, UniqueId = Guid.NewGuid(), Name = "Home-Error", ModuleController = "Home", ModuleAction = "Error", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 6, UniqueId = Guid.NewGuid(), Name = "User-Index", ModuleController = "User", ModuleAction = "Index", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 7, UniqueId = Guid.NewGuid(), Name = "KPIs-Index", ModuleController = "KPIs", ModuleAction = "Index", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 8, UniqueId = Guid.NewGuid(), Name = "Farms-Index", ModuleController = "Farms", ModuleAction = "Index", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 9, UniqueId = Guid.NewGuid(), Name = "Targets-Index", ModuleController = "Targets", ModuleAction = "Index", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 10, UniqueId = Guid.NewGuid(), Name = "Role-Index", ModuleController = "Role", ModuleAction = "Index", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 11, UniqueId = Guid.NewGuid(), Name = "RoleDetails-Update", ModuleController = "RoleDetails", ModuleAction = "Update", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 12, UniqueId = Guid.NewGuid(), Name = "RoleDetails-Get", ModuleController = "RoleDetails", ModuleAction= "Get", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 13, UniqueId = Guid.NewGuid(), Name = "Targets-Dashboard", ModuleController = "Targets", ModuleAction = "Dashboard", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 14, UniqueId = Guid.NewGuid(), Name = "UserRights-Fetch", ModuleController = "UserRights", ModuleAction = "Fetch", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 15, UniqueId = Guid.NewGuid(), Name = "RoleDetails-Fetch", ModuleController = "RoleDetails", ModuleAction = "Fetch", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 16, UniqueId = Guid.NewGuid(), Name = "UserRights-SaveDetails", ModuleController = "UserRights", ModuleAction = "SaveDetails", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 17, UniqueId = Guid.NewGuid(), Name = "RoleDetails-SaveDetails", ModuleController = "RoleDetails", ModuleAction = "SaveDetails", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 18, UniqueId = Guid.NewGuid(), Name = "KPIs-Edit", ModuleController = "KPIs", ModuleAction = "Edit", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 19, UniqueId = Guid.NewGuid(), Name = "KPIs-Details", ModuleController = "KPIs", ModuleAction = "Details", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 20, UniqueId = Guid.NewGuid(), Name = "KPIs-Delete", ModuleController = "KPIs", ModuleAction = "Delete", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 21, UniqueId = Guid.NewGuid(), Name = "KPIs-Create", ModuleController = "KPIs", ModuleAction = "Create", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 22, UniqueId = Guid.NewGuid(), Name = "Targets-Create", ModuleController = "Targets", ModuleAction = "Create", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 23, UniqueId = Guid.NewGuid(), Name = "Targets-Edit", ModuleController = "Targets", ModuleAction = "Edit", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 24, UniqueId = Guid.NewGuid(), Name = "User-Add", ModuleController = "User", ModuleAction = "Add", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 25, UniqueId = Guid.NewGuid(), Name = "User-Edit", ModuleController = "User", ModuleAction = "Edit", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 26, UniqueId = Guid.NewGuid(), Name = "Role-Add", ModuleController = "Role", ModuleAction = "Add", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 27, UniqueId = Guid.NewGuid(), Name = "Role-Edit", ModuleController = "Role", ModuleAction = "Edit", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 28, UniqueId = Guid.NewGuid(), Name = "Role-Delete", ModuleController = "Role", ModuleAction = "Delete", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 29, UniqueId = Guid.NewGuid(), Name = "User-Delete", ModuleController = "User", ModuleAction = "Delete", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 30, UniqueId = Guid.NewGuid(), Name = "Modules-Add", ModuleController = "Modules", ModuleAction = "Add", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 31, UniqueId = Guid.NewGuid(), Name = "Modules-Edit", ModuleController = "Modules", ModuleAction = "Edit", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 32, UniqueId = Guid.NewGuid(), Name = "Modules-Delete", ModuleController = "Modules", ModuleAction = "Delete", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 33, UniqueId = Guid.NewGuid(), Name = "test", ModuleController = "test", ModuleAction = "test", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 34, UniqueId = Guid.NewGuid(), Name = "targets-checkYear", ModuleController = "targets", ModuleAction = "checkYear", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 35, UniqueId = Guid.NewGuid(), Name = "Targets-Details", ModuleController = "Targets", ModuleAction = "Details", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 36, UniqueId = Guid.NewGuid(), Name = "User-UserProfile", ModuleController = "User", ModuleAction = "UserProfile", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 37, UniqueId = Guid.NewGuid(), Name = "Targets-Delete", ModuleController = "Targets", ModuleAction = "Delete", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 38, UniqueId = Guid.NewGuid(), Name = "User-EditProfile", ModuleController = "User", ModuleAction = "EditProfile", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 39, UniqueId = Guid.NewGuid(), Name = "Reports-Index", ModuleController = "Reports", ModuleAction = "Index", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 40, UniqueId = Guid.NewGuid(), Name = "Reports-Docs", ModuleController = "Reports", ModuleAction = "Docs", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 41, UniqueId = Guid.NewGuid(), Name = "Reports-getTargetYear", ModuleController = "Reports", ModuleAction = "getTargetYear", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 42, UniqueId = Guid.NewGuid(), Name = "Reports-UserDocs", ModuleController = "Reports", ModuleAction = "UserDocs", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 43, UniqueId = Guid.NewGuid(), Name = "Reports-admin", ModuleController = "Reports", ModuleAction = "admin", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 44, UniqueId = Guid.NewGuid(), Name = "KPIs-Dashboard", ModuleController = "KPIs", ModuleAction = "Dashboard", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 45, UniqueId = Guid.NewGuid(), Name = "KPIs-checkDuplicate", ModuleController = "KPIs", ModuleAction = "checkDuplicate", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 46, UniqueId = Guid.NewGuid(), Name = "kpis-checkKPIDuplicate", ModuleController = "kpis", ModuleAction = "checkKPIDuplicate", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 47, UniqueId = Guid.NewGuid(), Name = "kpis-ValidateYear", ModuleController = "kpis", ModuleAction = "ValidateYear", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 48, UniqueId = Guid.NewGuid(), Name = "targets-ValidateYear", ModuleController = "targets", ModuleAction = "ValidateYear", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 49, UniqueId = Guid.NewGuid(), Name = "Farms-Create", ModuleController = "Farms", ModuleAction = "Create", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 50, UniqueId = Guid.NewGuid(), Name = "Farms-Edit", ModuleController = "Farms", ModuleAction = "Edit", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 51, UniqueId = Guid.NewGuid(), Name = "Farms-Details", ModuleController = "Farms", ModuleAction = "Details", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 52, UniqueId = Guid.NewGuid(), Name = "Farms-Delete", ModuleController = "Farms", ModuleAction = "Delete", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 53, UniqueId = Guid.NewGuid(), Name = "Farms-GetAllLocation", ModuleController = "Farms", ModuleAction = "GetAllLocation", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 54, UniqueId = Guid.NewGuid(), Name = "Farms-Location", ModuleController = "Farms", ModuleAction = "Location", IsDeleted = false });
                context.Modules.Add(new Module { ModuleId = 55, UniqueId = Guid.NewGuid(), Name = "Farms-GetAllLocationById", ModuleController = "Farms", ModuleAction = "GetAllLocationById", IsDeleted = false });
                

            }
            context.SaveChanges();
        }
    }
}
