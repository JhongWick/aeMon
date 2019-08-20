using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRoleData
    {
        public static List<UserRole> ListAll()
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public static List<UserRole> ListAllWithIsDeleted()
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.ToList();
            }
        }

        public static bool Save(int userid, int roleid)
        {
            using (DBContext context = new DBContext())
            {
                UserRole userrole = new UserRole();
                userrole.UserId = userid;
                userrole.RoleId = roleid;

                context.UserRoles.Add(userrole);
                context.SaveChanges();
                return true;

            }
        }
        //public static string GetEmpId(int UserId)
        //{
        //    using (DBContext context = new DBContext())
        //    {
        //        return context.Users.Where(a => a.UserId == UserId).SingleOrDefault().EmployeeID;

        //    }
        //}

        public static string GetRoleName(int empId)

        {
            using (DBContext context = new DBContext())
            {


                return context.Roles.Where(a => a.RoleId == empId).SingleOrDefault().Name;
            }
        }
        //public static string GetFirstName(string empId)
        //{
        //    using (DBContext context = new DBContext())
        //    {
        //        return context.Employees.Where(a => a.EmployeeID == empId).SingleOrDefault().FirstName;
        //    }
        //}

        //public static string GetMiddleName(string empId)
        //{
        //    using (DBContext context = new DBContext())
        //    {
        //        return context.Employees.Where(a => a.EmployeeID == empId).SingleOrDefault().LastName;
        //    }
        //}

        //public static string GetLastName(string empId)
        //{
        //    using (DBContext context = new DBContext())
        //    {
        //        return context.Employees.Where(a => a.EmployeeID == empId).SingleOrDefault().LastName;
        //    }
        //}
        //public static int GetEmpUserId(string EmpId)

        //{
        //    using (DBContext context = new DBContext())
        //    {
        //        string EmployeeId = context.Employees.Where(a => a.EmployeeID == EmpId).SingleOrDefault().EmployeeID;
        //        return context.Users.Where(a => a.EmployeeID == EmployeeId).SingleOrDefault().UserId;
        //    }
        //}

        public static string GetEmpUserName(int userId)

        {
            using (DBContext context = new DBContext())
            {

                return context.Users.Where(a => a.UserId == userId).SingleOrDefault().UserName;
            }
        }

        public static int GetEmprole(int userId)

        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.Where(a => a.UserId == userId).SingleOrDefault().RoleId;

            }
        }

        public static bool IsDeleted(int userId)

        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.Where(a => a.UserId == userId).SingleOrDefault().IsDeleted;

            }
        }


        public static bool DeleteuserRole(int userId)
        {
            using (DBContext context = new DBContext())
            {
                UserRole user = context.UserRoles.Where(a => a.UserId == userId).SingleOrDefault();
                user.IsDeleted = true;
                //context.UserRole.Remove(user);
                context.SaveChanges();
                return true;
            }
        }

        public static bool SaveEditRole(int UserId, int selId, bool IsDeleted)
        {
            using (DBContext context = new DBContext())
            {
                UserRole user = context.UserRoles.Where(a => a.UserId == UserId).SingleOrDefault();
                user.UserId = user.UserId;
                user.RoleId = selId;
                user.IsDeleted = IsDeleted;
                context.SaveChanges();
                return true;
            }
        }
        public static UserRole GetByUserId(int userid)
        {
            using (DBContext context = new DBContext())
            {
                return context.UserRoles.Where(o => o.UserId == userid).SingleOrDefault();
            }
        }

        //public static string GeUserDiv(int UserId)

        //{
        //    using (DBContext context = new DBContext())
        //    {
        //        string emp = context.Users.Where(a => a.UserId == UserId).SingleOrDefault().EmployeeID;
        //        int divId = context.Employees.Where(a => a.EmployeeID == emp).SingleOrDefault().DivisionId;
        //        return context.DICTDivisions.Where(a => a.DivisionId == divId).SingleOrDefault().Name;
        //        //return context.DICTServices.Where(a => a.ServiceId == servId).SingleOrDefault().Description;

        //    }
        //}
        //public static string UserDiv(int DivId)

        //{
        //    using (DBContext context = new DBContext())
        //    {

        //        return context.DICTDivisions.Where(a => a.DivisionId == DivId).SingleOrDefault().Name;

        //    }
        //}

    }
}
