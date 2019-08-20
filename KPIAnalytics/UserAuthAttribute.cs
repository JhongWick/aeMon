using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KPIAnalytics
{
    public class UserAuthAttribute : AuthorizeAttribute
    {
        private readonly int[] allowedroles;
        private Uri prev;

        public UserAuthAttribute()
        {
            this.allowedroles = new int[] { 1 };
            this.prev = System.Web.HttpContext.Current.Request.UrlReferrer;
        }
        public static void SessionEnd()
        {
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = true;
            UserModel um = Authentication.CurrentUser;
            if (um == null)
            {
                authorize = false;
            }
            return authorize;

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var values = new RouteValueDictionary(new
            {
                action = "Error",
                controller = "Home",
                prev = this.prev
            });
            filterContext.Result = new RedirectToRouteResult(values);

        }

    }
}