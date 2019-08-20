using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DataAccessLayer
{

    public static class Authentication
    {
        public static string state { get; set; }
        public static bool IsAuthenticated { get { return _IsAuthenticated(); } set { } }
        public static int UserId { get; set; }
        public static UserModel CurrentUser
        {
            get
            {
                return UserMData(CookieeUserId());
            }
            set { }
        }
        public static int CookieeUserId()
        {

            
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket auth = FormsAuthentication.Decrypt(cookie.Value);
                int Id = Convert.ToInt32(auth.Name);
                return Id;
            }
            else
            {
                return 0;
            }
        }

        public static UserModel UserMData(int UserId)
        {
            //System.Web.HttpContext.Current.Session["Session"] = "On";
            //state = "On";
            if (UserId == 0)
            {
                return new UserModel();
            }
            User _user = UserData.ListAll().Where(o => o.UserId == UserId).SingleOrDefault();
            //Employee emp = EmployeeData.ListAll().Where(o => o.EmployeeID == _user.EmployeeID).SingleOrDefault();

            UserModel Um = new UserModel();

            Um.UserId = _user.UserId;
            Um.UniqueId = _user.UniqueId;
            Um.Password = _user.Password;
            Um.UserName = _user.UserName;
            
            Um.FirstName = _user.FirstName;
            Um.LastName = _user.LastName;
            Um.MiddleName = _user.MiddleName;
            Um.EmailAddress = _user.Email;
           

            return Um;

        }

        public static bool IsCookieAuthenticated()
        {
            int _userid = CookieeUserId();
            if (_userid == 0)
            { return false; }
            else
            {
                return true;
            }
        }

        public static bool IsLoginCorrect(string username, string password)
        {
            //string hashedpassword = Helper.ConvertTextToMD5(password);
            using (DBContext context = new DBContext())
            {
                bool result = context.Users.Any((w => w.UserName.ToLower() == username.ToLower() && w.Password == password));

                return result;
            }
        }

        public static bool IsUserAuthorized(string username, string action, string controller)
        {
            int newmodId = 0;
            if (username == "" || username == null)
                return false;
            using (DBContext context = new DBContext())
            {
                if (!context.Modules.Any(w => w.ModuleAction == action && w.ModuleController == controller))
                {
                    Module _data = new Module();
                    _data.Name = "!NEW " + controller + "-" + action;
                    _data.ModuleController = controller;
                    _data.ModuleAction = action; 
                    _data.UniqueId = Guid.NewGuid(); 
                    // Library.AddModule(_data);
                    newmodId = Library.AddModule(_data, 0);
                }
                int moduleID = Helper.GetModuleIDByControllerAction(controller, action);
                int UserId = Helper.GetUserIDByName(username);

                if (context.UserRights.Any(w => w.UserId == UserId && w.ModuleId == moduleID))
                {
                    return context.UserRights.Where(w => w.UserId == UserId && w.ModuleId == moduleID).SingleOrDefault().IsAllowed;
                }

                if (!context.UserRoles.Any(w => w.UserId == UserId))
                {
                    return false;
                }
                int RoleId = Helper.GetUserRoleByID(UserId);
                RoleDetail detail = context.RoleDetails.Where(w => w.RoleId == RoleId && w.ModuleId == moduleID).SingleOrDefault();
                if (detail == null)
                {
                    RoleDetail newdetail = new RoleDetail();
                    newdetail.IsAllowed = false;
                    newdetail.ModuleId = moduleID;
                    newdetail.RoleId = RoleId;
                    context.RoleDetails.Add(newdetail);
                    context.SaveChanges();
                }
                return context.RoleDetails.Where(w => w.RoleId == RoleId && w.ModuleId == moduleID).Single().IsAllowed;
            }
        }



        public static FormsAuthenticationTicket Cookiee()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                return FormsAuthentication.Decrypt(cookie.Value);
            }
            else
            {
                return null;
            }
        }

        public static bool _IsAuthenticated()
        {
            if (Authentication.Cookiee() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }


}
