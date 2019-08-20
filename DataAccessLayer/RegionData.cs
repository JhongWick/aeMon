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
    }
}
