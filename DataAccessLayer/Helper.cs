using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Helper
    {
        public static List<RoleDetail> GetRoleDetailByRoleID(int roleId)
        {
            using (DBContext context = new DBContext())
            {
                return context.RoleDetails.Where(w => w.RoleId == roleId).ToList();
            }
        }
        public static List<RoleDetail> GetRoleDetailListByModuleID(int moduleId)
        {
            using (DBContext context = new DBContext())
            {
                return context.RoleDetails.Where(w => w.ModuleId == moduleId).ToList();
            }
        }
        public static List<Role> GetRoleList()
        {
            using (DBContext context = new DBContext())
            {
                return context.Roles.Where(x => x.IsDeleted == true).ToList();
            }
        }
        public static List<User> GetUserList()
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(x => x.IsDeleted == false).ToList();
            }
        }
        public static List<UserRole> GetUserRoleList()
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.ToList();
            }
        }
        public static List<UserRole> GetUserRoleListByUserId(int userid)
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.Where(w => w.UserId == userid).ToList();
            }
        }
        public static List<UserRight> GetUserRightListByUserID(int userId)
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRights.Where(w => w.UserId == userId).ToList();
            }
        }
        public static List<Module> GetModuleList()
        {
            using (DBContext context = new DBContext())
            {
                return context.Modules.ToList();
            }
        }


        public static UserRole GetUserRoleByUserID(int Userid)
        {
            using (DBContext context = new DBContext())
            {
                UserRole _userRole = context.UserRoles.Where(w => w.UserId == Userid).SingleOrDefault();
                if (_userRole == null)
                {
                    UserRole _userRole2 = new UserRole();
                    _userRole2.UserId = Userid;
                    _userRole2.RoleId = 0;
                    _userRole2.Id = 0;
                    return _userRole2;
                }
                return _userRole;
            }
        }
        public static UserRight GetUserRightByUserID(int userId)
        {
            using (DBContext context = new DBContext())
            {
                UserRight _data = new UserRight();
                _data.UserId = userId;
                _data.IsAllowed = false;
                return _data;
            }
        }
        public static Role GetRoleByID(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Roles.Where(w => w.RoleId == id).SingleOrDefault();
            }
        }

        public static User GetUserByID(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(w => w.UserId == id).SingleOrDefault();
            }
        }
        public static User GetUserByUsername(string userNaMe)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(w => w.UserName == userNaMe).SingleOrDefault();
            }
        }
        public static Module GetModuleByID(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Modules.Where(w => w.ModuleId == id).SingleOrDefault();
            }
        }

        public static int GetUserIDByName(string username)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(w => w.UserName == username).SingleOrDefault().UserId;
            }
        }
        public static int GetUserRoleByID(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.Where(w => w.UserId == id).SingleOrDefault().RoleId;
            }
        }
        public static int GetModuleIDByControllerAction(string controller, string action)
        {
            using (DBContext context = new DBContext())
            {
                return context.Modules.Where(w => w.ModuleAction == action && w.ModuleController == controller).FirstOrDefault().ModuleId;
            }
        }

        public static string GetUserNameByID(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(w => w.UserId == id).SingleOrDefault().UserName;
            }
        }
        public static string GetRoleNameByID(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Roles.Where(w => w.RoleId == id).SingleOrDefault().Name;
            }
        }

        public static string ConvertTextToMD5(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return "";
            }
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(text);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }

        //  adds
        public static bool IsMaintenanceAllowed(string name)
        {
            using (DBContext context = new DBContext())
            {
                User user = context.Users.Where(o => o.UserName == name).SingleOrDefault();
                if (user == null)
                {
                    return false;
                }
                UserRole role = GetUserRole(user.UserId);
                if (role == null)
                {
                    return false;
                }
                RoleDetail detail = GetRoleDetail(role.RoleId);
                if (detail == null)
                {
                    return false;
                }
                if (detail.IsAllowed)
                {
                    return true;
                }
                return false;
            }
        }
        public static UserRole GetUserRole(int userid)
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.Where(o => o.UserId == userid).SingleOrDefault();
            }
        }
        public static RoleDetail GetRoleDetail(int roleid)
        {
            using (DBContext context = new DBContext())
            {
                int ModuleId = 0;

                Module module = context.Modules.Where(o => o.ModuleController == "RoleDetails").FirstOrDefault();
                if (module == null)
                {
                    Module module1 = new Module { ModuleAction = "Update", ModuleController = "RoleDetails", Name = "RoleDetails Update" };
                    context.Modules.Add(module1);
                    context.SaveChanges();
                    ModuleId = module1.ModuleId;
                }
                else
                {
                    ModuleId = module.ModuleId;
                }

                return context.RoleDetails.Where(o => o.RoleId == roleid && o.ModuleId == ModuleId).SingleOrDefault();
            }
        }
    }
}
