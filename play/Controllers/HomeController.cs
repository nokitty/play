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
            return View();
        }

        [HttpPost]
        public ActionResult Upload(string name, int chunk, int chunks, HttpPostedFileBase data)
        {
            var result = new AjaxResult();
            return Json(result);
        }
    }

    class AjaxResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AjaxResult()
        {
            Success = true;
            Message = "ok";
        }
    }
}
