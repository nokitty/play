using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace play.Controllers
{
    public class HttpMethodController : Controller
    {
        //Get
        public ActionResult Index()
        {
            return View();
        }

        ActionResult Create()
        {
            return View();
        }

        ActionResult Update()
        {
            return View();
        }

        ActionResult Delete()
        {
            return View();
        }
    }
}
