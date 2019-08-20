using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using DataAccessLayer;
using System.Collections.Generic;
using Entities;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace KPIAnalytics.Controllers
{
    [KPIAuthorize]

    [UserAuth]
    public class UserController : Controller
    {
        private DBContext db = new DBContext();
        // GET: User
        public ActionResult Index()
        {
            List<User> model = new List<User>();
            model = UserData.ListAll();
            return View(model);
        }
        public ActionResult UserProfile(int id)
        {
            User _user = UserData.FetchUser(id);
            
            return View(_user);
        }
        [AllowAnonymous]
        public JsonResult CheckDuplicate(string username)
        {
            bool result = UserData.CheckDuplicateUserName(username);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
           
            ViewBag.Region = db.Regions.ToList();
            //List<Employee> model = new List<Employee>();
            //model = EmployeeData.ListAll();
            //return PartialView("Add", model);
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User model, int RoleId)
        {
            model.Password = GetHashedPassword(model.Password);
            bool result = UserData.Add(model, RoleId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int UserId)
        {
            User user = UserData.Fetch(UserId);
            return PartialView("Delete", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User model)
        {
            bool result = UserData.Delete(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int UserId)
        {
            ViewBag.Region = db.Regions.ToList();
            User user = UserData.Fetch(UserId);
            UserRole role = UserRoleData.GetByUserId(user.UserId);
            ViewBag.Role = role.RoleId;
            return PartialView("Edit", user);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model, int RoleId)
        {
            if (model.Password != null)
            {
                model.Password = GetHashedPassword(model.Password);
            }
            bool result = UserData.Edit(model, RoleId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult EditProfile(int UserId)
        {
            User user = UserData.Fetch(UserId);
            return PartialView("EditProfile", user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(User model)
        {
            if (model.Password != null)
            {
                model.Password = GetHashedPassword(model.Password);
            }
            bool result = UserData.Edit(model, null);
            if (result)
            {
                return RedirectToAction("UserProfile", new { id = model.UserId});
            }
            else
            {
                return View();
            }
        }
        public static string GetHashedPassword(string password)
        {
            string salt = "KPI";
            byte[] byteSalt = UnicodeEncoding.Unicode.GetBytes(salt);
            byte[] bytePass = UnicodeEncoding.Unicode.GetBytes(password);
            byte[] combinedBytes = new byte[bytePass.Length + byteSalt.Length];
            Buffer.BlockCopy(bytePass, 0, combinedBytes, 0, bytePass.Length);
            Buffer.BlockCopy(byteSalt, 0, combinedBytes, bytePass.Length, byteSalt.Length);
            HashAlgorithm hashPass = new SHA256Managed();
            byte[] hash = hashPass.ComputeHash(combinedBytes);
            byte[] hashPlusSalt = new byte[hash.Length + byteSalt.Length];
            Buffer.BlockCopy(hash, 0, hashPlusSalt, 0, hash.Length);
            Buffer.BlockCopy(byteSalt, 0, hashPlusSalt, hash.Length, byteSalt.Length);
            string hashedPassword = UnicodeEncoding.Unicode.GetString(hashPlusSalt);
            return hashedPassword;
        }
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}