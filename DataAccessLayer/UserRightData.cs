using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRightData
    {
        public static List<UserRight> GetList()
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRights.ToList();
            }
        }
        public static UserRight FindUserRight(int UserId, int ModuleId)
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRights.Where(o => o.UserId == UserId && o.ModuleId == ModuleId).SingleOrDefault();
            }
        }
        static UserRight Find(int UserId, int ModuleId)
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRights.Where(o => o.UserId == UserId && o.ModuleId == ModuleId).SingleOrDefault();
            }
        }
        public static bool Save(int UserId, string[] id, string[] names, string[] status, string[] saveflag)
        {
            using (DBContext context = new DBContext())
            {
                List<UserRight> userrights = context.UserRights.Where(o => o.UserId == UserId).ToList();

                for (int i = 0; i < id.Count(); i++)
                {

                    UserRight userright = Find(UserId, Convert.ToInt32(id[i]));
                    if (userright == null)
                    {
                        if (Convert.ToBoolean(saveflag[i]))
                        {
                            UserRight ur = new UserRight();
                            ur.UserId = UserId;
                            ur.ModuleId = Convert.ToInt32(id[i]);
                            ur.IsAllowed = Convert.ToBoolean(status[i]);
                            context.UserRights.Add(ur);
                        }

                    }
                    else
                    {
                        int mid = Convert.ToInt32(id[i]);
                        UserRight ur = context.UserRights.Where(o => o.UserId == UserId && o.ModuleId == mid).SingleOrDefault();
                        if (Convert.ToBoolean(saveflag[i]))
                        {
                            ur.IsAllowed = Convert.ToBoolean(status[i]);
                        }
                        else
                        {
                            context.UserRights.Remove(ur);
                        }
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

    }
}
