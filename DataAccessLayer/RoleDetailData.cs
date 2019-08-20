using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleDetailData
    {
        public static List<RoleDetail> GetById(int Id)
        {
            using (DBContext context = new DBContext())
            {
                return context.RoleDetails.Where(o => o.RoleId == Id).ToList();
            }
        }
        public static bool Save(string roleid, string[] id, string[] names, string[] status)
        {
            int _roleid = Convert.ToInt32(roleid);
            using (DBContext context = new DBContext())
            {
                List<RoleDetail> details = context.RoleDetails.Where(o => o.RoleId == _roleid).ToList();


                for (int i = 0; i < id.Count(); i++)
                {
                    int moduleid = Convert.ToInt32(id[i]);
                    RoleDetail role = context.RoleDetails.Where(o => o.RoleId == _roleid && o.ModuleId == moduleid).SingleOrDefault();
                    if (role == null)
                    {
                        RoleDetail _rd = new RoleDetail();
                        _rd.RoleId = _roleid;
                        _rd.ModuleId = Convert.ToInt32(id[i]);
                        _rd.IsAllowed = Convert.ToBoolean(status[i]);
                        context.RoleDetails.Add(_rd);
                    }
                    else
                    {
                        role.IsAllowed = Convert.ToBoolean(status[i]);
                    }

                }
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        static RoleDetail Find(int RoleId, int ModuleId)
        {
            using (DBContext context = new DBContext())
            {
                return context.RoleDetails.Where(o => o.RoleId == RoleId && o.ModuleId == ModuleId).SingleOrDefault();
            }
        }
    }
}
