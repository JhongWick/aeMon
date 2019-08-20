using DataAccessLayer;
using Entities;
using KPIAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace KPIAnalytics.Controllers
{
    [UserAuth]
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PNCIC()
        {
            return View();
        }

        public ActionResult RDandHVDP()
        {
            return View();
        }
        public ActionResult Roadmap()
        {
            return View();
        }
        [KPIAuthorize]

        public ActionResult Dashboard()
        {
            List<Farms> _farmList = db.Farms.ToList();
            string[] labels = new string[_farmList.Count()];
            
            int counter = 0;
            foreach (var item in _farmList)
            {
                string labelTemp = item.Barangay.ToString();
                labels[counter] = labelTemp.Substring(0, 1);
               
                counter++;
            }

            ViewBag.Label = labels;

            bool has = false;
            int year = DateTime.Now.Year;
            Target _currentTarget = new Target();
            List<Target> _ListTarget = db.Targets.ToList();
            int tempArrayCount = 0;
            foreach (var item in _ListTarget)
            {
                for (int count = item.YearStart - 1; count < item.YearEnd; count++)
                {
                    tempArrayCount++;
                }

                int[] tempYearArray = new int[tempArrayCount];

                for (int value = item.YearStart; value < item.YearEnd + 1; value++)
                {

                    tempYearArray[value - item.YearStart] = value;
                }

                has = tempYearArray.Contains(year);
                if (has)
                {
                    ViewBag.YearCovered = tempYearArray;
                    _currentTarget = db.Targets.Find(item.TargetId);
                }
            }
            
            return View(_currentTarget);
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult LogIn(string returnUrl)
        {
            if (Authentication.Cookiee() != null)
            {

                if (Authentication.state != null && Authentication.UserId != 0)
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    Out();
                }
            }

            ViewBag.DisplayError = false;
            //if (string.IsNullOrEmpty(returnUrl) && Request.UrlReferrer != null)
            //    returnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);

            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnURL = returnUrl;
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnURL = returnUrl;
            }
            //-------authentication--------
            return View("Login");
        }
        [HttpPost]
        public ActionResult LogIn(LogInModel model, string returnUrl)
        {
            ViewBag.DisplayError = true;
            string decodedUrl = "";


            if (VerifyLogin(model.UserName, model.Password, model.RememberMe))
            {

                int role = UserRoleData.GetByUserId(Authentication.CurrentUser.UserId).RoleId;
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    decodedUrl = Server.UrlDecode(returnUrl);
                    return Redirect(decodedUrl);
                }
                else
                {
                    if (role == 1 || role == 2)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }

                }
            }
            else { ViewBag.ErrorLogin = true; }
            ViewBag.ReturnURL = returnUrl;
            return View();
        }

        //public ActionResult CreateAccount(Guid UniqueId, int RoleId, int UserInvite)
        //{
        //    UserInvite invite = CreateAccountData.GetStatus(UserInvite);
        //    if (invite == null)
        //    {
        //        return RedirectToAction("Login", "Home");
        //    }
        //    else
        //    {
        //        if (invite.EmpUniqueId == UniqueId && invite.RoleId == RoleId)
        //        {
        //            bool Status = CreateAccountData.GetStatus(UserInvite).IsCreated;
        //            if (Status)
        //            {
        //                return RedirectToAction("Login", "Home");

        //            }
        //            else
        //            {
        //                ViewBag.Empname = CreateAccountData.GetEmp(UniqueId).FirstName;
        //                ViewBag.EmpId = UniqueId;
        //                ViewBag.Role = RoleId;
        //                ViewBag.UserInvites = UserInvite;
        //                return View();
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }
        //    }
        //}
        //public ActionResult SaveUser(string UserName, string ConfirmPassword, string Password, string EmpId, int Role, int userInvites)
        //{
        //    bool user = UserData.CheckDuplicateUserName(UserName);
        //    if (user)
        //    {
        //        string error = "Username is already use";
        //        return Json(new { isSuccess = true, error, url = false }, JsonRequestBehavior.AllowGet);

        //    }
        //    else
        //    {
        //        if (Password == ConfirmPassword)
        //        {

        //            using (eProcContext context = new eProcContext())
        //            {
        //                UserInvite status = context.UserInvites.Where(o => o.UserInviteId == userInvites).SingleOrDefault();
        //                Employee Emp = context.Employees.Where(o => o.UniqueId.ToString() == EmpId).SingleOrDefault();
        //                User User = new User();
        //                User.Password = UserController.GetHashedPassword(Password);
        //                User.UserName = UserName;
        //                User.UniqueId = Guid.NewGuid();
        //                User.EmployeeID = Emp.EmployeeID;
        //                context.Users.Add(User);
        //                context.SaveChanges();
        //                UserRole UserRole = new UserRole();
        //                UserRole.UserId = User.UserId;
        //                UserRole.RoleId = Role;
        //                context.UserRole.Add(UserRole);
        //                status.IsCreated = true;
        //                context.SaveChanges();
        //            }


        //            return Json(new { isSuccess = true, url = true }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            string error = "Password did not Match";
        //            return Json(new { isSuccess = true, error, url = false }, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //}


        [HttpPost]
        public ActionResult LogOff()
        {
            ViewBag.ReturnURL = null;
            Out();
            return RedirectToAction("Login", "Home");

        }


        public bool VerifyLogin(string username, string password, bool rememberme)
        {
            if (password == null)
            { return false; }

            else
            {
                password = UserController.GetHashedPassword(password);
                if (Authentication.IsLoginCorrect(username, password))
                {
                    Authentication.IsAuthenticated = true;
                    User user = UserData.GetByUserNameAndPassword(username, password);
                    Authentication.UserId = user.UserId;
                    FormsAuthentication.SetAuthCookie(user.UserId.ToString(), rememberme);
                    return true;
                }
                return false;
            }
        }

        public static void Out()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session.Abandon();

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie1);

            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie2);

            System.Web.HttpContext.Current.Session["UniqueId"] = null;
            System.Web.HttpContext.Current.Session["UserName"] = null;
            System.Web.HttpContext.Current.Session["DivisionId"] = null;
            System.Web.HttpContext.Current.Session["ServiceId"] = null;
            System.Web.HttpContext.Current.Session["UserRole"] = null;
        }

        public ActionResult Error(string returnUrl)
        {
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        // Errors
        public ActionResult Error401(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error403(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error404(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error405(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error406(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error412(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error500(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error501(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }

        public ActionResult Error502(string returnUrl, Uri prev)
        {
            ViewBag.Prev = prev;
            ViewBag.ReturnView = returnUrl;
            return View();
        }
    }
}