using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SgmSystemV1.Security
{
    public class AreaAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string area;

        public AreaAuthorizeAttribute(string area)
        {
            this.area = area;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string loginUrl = "";

            if(area == "Admin")
            {
                loginUrl = "~/Admin/Account/Login";
            }else
            {
                loginUrl = "~/Account/Login";
            }
            filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Url.PathAndQuery);
        }
    }
}