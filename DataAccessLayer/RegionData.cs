using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RegionData
    {
        public static List<Region> ListAll()
        {
            using (DBContext Context = new DBContext())
            {
                return Context.Regions.ToList();
                //return Context.CSECategories.ToList();
            }
        }

        public static Region Fetch(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Regions.Where(w => w.RegionId == id).SingleOrDefault();
            }
        }

     
        public static string  returnName(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Regions.Where(o => o.RegionId == id).SingleOrDefault().Name;
            }
        }

        public static bool Add(Region obj)
        {
            using (DBContext Context = new DBContext())
            {
                obj.UniqueId = Guid.NewGuid();
                Context.Regions.Add(obj);
                try
                { Context.SaveChanges(); }
                catch
                { return false; }
                return true;
            }
        }
        public static bool Delete(Region obj)
        {
            bool result = false;
            using (DBContext context = new DBContext())
            {

                Region region = context.Regions.SingleOrDefault(o=>o.RegionId == obj.RegionId);
                if (region != null)
                {
                    context.Regions.Remove(region);
                   
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public static bool Edit(Region obj)
        {
            using (DBContext context = new DBContext())
            {
                Region region = context.Regions.Where(o => o.RegionId == obj.RegionId).SingleOrDefault();
                region.Name = obj.Name;
                region.RegionId = obj.RegionId;
                region.Code = obj.Code;
              
                try
                { context.SaveChanges(); }
                catch
                { return false; }
                return true;
            }
        }
    }
}
