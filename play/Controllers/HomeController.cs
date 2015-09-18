using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using play.Models;

namespace play.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var user = new User { ID = 1, Name = "aab" };
            Security.Login(user);
            //Security.Logout();
            //var b = Security.IsLogin;
            return Content("ok");
        }

    }
}
