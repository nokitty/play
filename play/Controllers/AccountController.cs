using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using play.Models;

namespace play.Controllers
{
    public class AccountController : ControllerBase
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            var user = DB.Users.Where(i => i.Name == name).FirstOrDefault();
            if (user == null || user.Password != password)
                return Content("用户名或密码错误");

            return View();
        }

        public ActionResult Logout()
        {
            Security.Logout();
            return Redirect("~/");
        }
    }
}
