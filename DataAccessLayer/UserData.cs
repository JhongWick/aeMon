using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class UserData
    {
        public static List<User> ListAll()
        {
            using (DBContext Context = new DBContext())
            {
                return Context.Users.Where(o => o.IsDeleted == false).ToList();
                //return Context.Users.ToList();
            }
        }

        public static User Fetch(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(w => w.UserId == id).SingleOrDefault();
            }
        }

        public static int ReturnRegionId(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(w => w.UserId == id).SingleOrDefault().Region;
            }
        }

        //public static string GetbyName(string id)
        //{
        //    using (DBContext context = new DBContext())
        //    {
        //        Employee emp = context.Employees.Where(w => w.EmployeeID == id.Trim()).SingleOrDefault();
        //        string name = "";
        //        if (emp.MiddleName != "")
        //        {
        //            name = String.Format("{0}, {1} {2}.", emp.LastName, emp.FirstName, emp.MiddleName.Substring(0, 1));
        //        }
        //        else
        //        {
        //            name = String.Format("{0}, {1} {2}.", emp.LastName, emp.FirstName, emp.MiddleName);
        //        }

        //        return name;
        //    }
        //}

        public static bool CheckDuplicateUserName(string username)
        {
            bool result = false;
            using (DBContext context = new DBContext())
            {
                User user1 = context.Users.SingleOrDefault(o => o.UserName.ToUpper() == username.Trim().ToUpper());
                if (user1 != null)
                {
                    result = true;
                }
            }
            return result;
        }

        public static bool Add(User obj, int RoleId)
        {
            using (DBContext Context = new DBContext())
            {
                obj.UniqueId = Guid.NewGuid();
                Context.Users.Add(obj);
                try
                {
                    Context.SaveChanges();
                    UserRole role = new UserRole()
                    {
                        RoleId = RoleId,
                        UserId = obj.UserId,
                        IsDeleted = false
                    };
                    
                    Context.UserRoles.Add(role);
                    Context.SaveChanges();
                }
                catch
                { return false; }
                return true;
            }
          
        }

        public static bool Delete(User obj)
        {
            bool result = false;
            using (DBContext context = new DBContext())
            {

                User user = context.Users.SingleOrDefault(o => o.IsDeleted == false && o.UserId == obj.UserId);
                if (user != null)
                {
                    user.IsDeleted = true;
                    context.SaveChanges();
                    result = true;

                    UserRole userrole = context.UserRoles.Where(a => a.IsDeleted == false && a.UserId == obj.UserId).SingleOrDefault();
                    userrole.IsDeleted = true;
                    context.SaveChanges();
                }
            }
            return result;
        }

        public static bool Edit(User obj, int? roleid)
        {
            using (DBContext context = new DBContext())
            {
                User user = context.Users.Where(o => o.UserId == obj.UserId).SingleOrDefault();
                user.UserName = obj.UserName;
                user.FirstName = obj.FirstName;
                user.MiddleName = obj.MiddleName;
                user.LastName = obj.LastName;
                user.NameExt = obj.NameExt;
                user.Email = obj.Email;
                user.ContactNumber = obj.ContactNumber;
                user.Region = obj.Region;
                if (obj.Password != null)
                {
                    user.Password = obj.Password;
                }
                user.IsDeleted = obj.IsDeleted;
                try
                { context.SaveChanges(); }
                catch
                { return false; }

                int _roleID = 0;
                if(roleid == null)
                {
                    UserRole role = UserRoleData.GetByUserId(user.UserId);
                    _roleID = role.RoleId;
                }
                else
                {
                    _roleID = roleid.Value;
                }
                UserRole userrole = context.UserRoles.Where(a => a.UserId == obj.UserId).SingleOrDefault();
                userrole.RoleId = _roleID;
                userrole.IsDeleted = obj.IsDeleted;
                context.SaveChanges();
                return true;
            }


        }







 
        public static List<User> FetchUsers()
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.ToList();
            }
        }
        public static User FetchUser(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(w => w.UserId == id).SingleOrDefault();
            }
        }
        public static User GetById(int Id)
        {
            using (DBContext context = new DBContext())
            {
                User obj = context.Users.Where(o => o.UserId == Id).SingleOrDefault();
                return obj;
            }
        }


        


        public static int GetDivisionId(int UserId)
        {
            using (DBContext context = new DBContext())
            {
                //return context.Users.Where(o => o.UserId == UserId).SingleOrDefault().DivisionId;
                return 1;
            }
        }
        public static User GetByUserNameAndPassword(string uname, string pword)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(o => o.UserName.ToLower() == uname.ToLower() && o.Password == pword).SingleOrDefault();
            }
        }
        public static string GetUserName(int Id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Users.Where(o => o.UserId == Id).SingleOrDefault().UserName;
            }
        }
        public static string GetUserCompleteName(int Id)
        {
            using (DBContext context = new DBContext())
            {
                User user = context.Users.Where(o => o.UserId == Id).SingleOrDefault();

                string CompleteName = user.FirstName + " " + user.MiddleName + " " + user.LastName + " " + user.NameExt;
                return CompleteName;
            }
        }
        public static int GetUserRegion(int Id)
        {
            using (DBContext context = new DBContext())
            {
                User user = context.Users.Where(o => o.UserId == Id).SingleOrDefault();

                return user.Region;
            }
        }

    }


}
