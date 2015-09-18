using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using play.Models;

namespace play.Controllers
{
    [MyAuthorize(PermissionSet.User)]
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return Content("用户-主页");
        }

        [MyAuthorize(PermissionSet.UserCreate)]
        public ActionResult Create()
        {
            return Content("用户-创建");
        }

        [MyAuthorize(PermissionSet.UserDelete)]
        public ActionResult Delete()
        {
            return Content("用户-删除");
        }

        [MyAuthorize(PermissionSet.UserEdit)]
        public ActionResult Edit()
        {
            return Content("用户-编辑");
        }
    }
}
