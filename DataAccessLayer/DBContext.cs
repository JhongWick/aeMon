using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
 
    public class DBContext : DbContext
    {
        public DBContext() : base("KPIAnalytics_Connection") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<KPI> KPIs { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Right> Rights { get; set; }
        public DbSet<UserRight> UserRights { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleDetail> RoleDetails { get; set; }
        public DbSet<Farms> Farms { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<FileStorage> FileStorages { get; set; }
        public DbSet<Storage> Storages { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Role> Roles { get; set; }
    }
  

}
