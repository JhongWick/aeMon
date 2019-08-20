using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KPIAnalytics
{
    public class KPIAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly int[] allowedroles;
        private Guid Module;
        private string cur;
        private string _action;
        private string _controller;
        private string returnUrl;

        public KPIAuthorizeAttribute()
        {
            this.allowedroles = new int[] { 1 };
        }
        public static void SessionEnd()
        {
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            string currentUrl = HttpContext.Current.Request.Url.ToString().ToLower();
            _action = httpContext.Request.RequestContext.RouteData.Values["action"].ToString();
            _controller = httpContext.Request.RequestContext.RouteData.Values["controller"].ToString();
            int start = currentUrl.IndexOf(_controller.ToLower() + '/' + _action.ToLower());

            returnUrl = currentUrl.Substring(start, currentUrl.Length - start);
            returnUrl = currentUrl;
            start = start + _controller.Length + _action.Length + 1;
            cur = currentUrl.Substring(start, currentUrl.Length - start);
            // Module = ModuleData.Fetch(_action, _controller).UniqueId;
            // bool x = Authentication.IsAuthenticated(); 
            if (Authentication.IsAuthenticated)
            {


                if (Authentication.IsUserAuthorized(Authentication.CurrentUser.UserName, _action, _controller))
                {
                    authorize = true;
                }

            }
            return authorize;

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var values = new RouteValueDictionary(new
            {
                action = "Error",
                controller = "Home",
                returnUrl = returnUrl
            });
            filterContext.Result = filterContext.Result = new RedirectToRouteResult(values);

        }

    }
}