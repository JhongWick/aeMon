using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using KPIAnalytics.Models;
using DataAccessLayer;
using System.Collections.Generic;
using Entities;

namespace KPIAnalytics.Controllers
{
    [KPIAuthorize]

    [UserAuth]
    public class UserRightsController : Controller
    {
        // GET: UserRights
        [KPIAuthorize]
        public ActionResult Update()
        {
            ViewBag.Modules = ModuleData.GetModel(0);
            List<User> model = UserData.ListAll();
            return View(model);
        }
        public static int GetRoleId(int UserId)
        {
            UserRole role = UserRoleData.GetByUserId(UserId);
            if (role != null)
            {
                return role.RoleId;
            }
            else
            {
                return 0;
            }
        }
        public static string GetRoleName(int UserId)
        {
            UserRole role = UserRoleData.GetByUserId(UserId);
            if (role != null)
            {
                return RoleData.GetById(role.RoleId).Name;
            }
            else
            {
                return "n/a";
            }

        }
        public ActionResult SaveDetails(string[] id, string[] names, string[] status, string[] saveflag, string userid)
        {
            int UserId = Convert.ToInt32(userid);
            bool data = UserRightData.Save(UserId, id, names, status, saveflag);

            return this.Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Fetch(string Id)
        {
            if (Id == null) { Id = 0.ToString(); }
            UserRole ur = UserRoleData.GetByUserId(Convert.ToInt32(Id));
            if (ur == null)
            {
                return this.Json(new { result = "false" }, JsonRequestBehavior.AllowGet);
            }
            int RoleId = ur.RoleId;

            List<ModuleModel> model = ModuleData.GetModel(RoleId);
            //List<UserRight> model = UserRightData.GetList().Where(o=>o.UserId==Convert.ToInt32(Id)).ToList();

            ViewBag.RoleDetails = RoleDetailData.GetById(Convert.ToInt32(Id));
            ViewBag.Roles = RoleData.ListAll();
            ViewBag.Modules = ModuleData.GetList();
            string[] mId = new string[model.Count];
            string[] mName = new string[model.Count];
            string[] misAllowed = new string[model.Count];
            string[] misAllowedOverride = new string[model.Count];
            for (int i = 0; i < model.Count; i++)
            {

                mId[i] = model[i].ModuleId.ToString();
                mName[i] = model[i].Name.ToString();
                UserRight right = UserRightData.FindUserRight(Convert.ToInt32(Id), model[i].ModuleId);
                misAllowed[i] = model[i].IsAllowed.ToString();
                if (right == null)
                {
                    misAllowedOverride[i] = model[i].IsAllowed.ToString();
                }
                else
                {
                    misAllowedOverride[i] = right.IsAllowed.ToString();
                }
            }


            return this.Json(new { id = mId, name = mName, isallowed = misAllowed, isallowed2 = misAllowedOverride }, JsonRequestBehavior.AllowGet);
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