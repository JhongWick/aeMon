using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleData
    {
        public static List<Role> ListAll()
        {
            using (DBContext Context = new DBContext())
            {
                return Context.Roles.Where(o => o.IsDeleted == false).ToList();
                //return Context.CSECategories.ToList();
            }
        }

        public static Role Fetch(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Roles.Where(w => w.RoleId == id).SingleOrDefault();
            }
        }

        public static bool Add(Role obj)
        {
            using (DBContext Context = new DBContext())
            {
                obj.UniqueId = Guid.NewGuid();
                Context.Roles.Add(obj);
                try
                { Context.SaveChanges(); }
                catch
                { return false; }
                return true;
            }
        }

        public static bool Delete(Role obj)
        {
            bool result = false;
            using (DBContext context = new DBContext())
            {

                Role role = context.Roles.SingleOrDefault(o => o.IsDeleted == false && o.RoleId == obj.RoleId);
                if (role != null)
                {
                    role.IsDeleted = true;
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public static bool Edit(Role obj)
        {
            using (DBContext context = new DBContext())
            {
                Role role = context.Roles.Where(o => o.RoleId == obj.RoleId).SingleOrDefault();
                role.Name = obj.Name;
                role.IsDeleted = obj.IsDeleted;
                try
                { context.SaveChanges(); }
                catch
                { return false; }

                return true;
            }
        }
        public static Role GetById(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Roles.Where(o => o.RoleId == id).SingleOrDefault();
            }
        }
    }
}
