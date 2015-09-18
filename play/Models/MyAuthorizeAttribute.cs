using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using play.Models;

namespace play.Models
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public string[] Permissions { get; set; }

        public MyAuthorizeAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return Security.CheckPermissions(Permissions);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (Security.IsLogin == false)
                filterContext.Result = new ContentResult() { Content = "请先登录" };
            else
                filterContext.Result = new ContentResult() { Content = "权限不足" };
        }
    }
}