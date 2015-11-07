using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace play.Controllers
{
    public class MultiUploadController : Controller
    {
        //
        // GET: /MultiUpload/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] file)
        {
            return View();
        }
    }
}
