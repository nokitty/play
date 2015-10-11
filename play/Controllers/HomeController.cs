using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using play.Models;
using Crc32C;

namespace play.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var crc32 = Crc32C.Crc32CAlgorithm.Compute(System.Text.Encoding.UTF8.GetBytes("this is a string"));
            return Content(crc32.ToString());
        }

        public ActionResult A()
        {
            return View();
        }

        public ActionResult Page()
        {
            return PartialView("page");
        }

        [HttpPost]
        public ActionResult Upload(string name, int chunk, int chunks, HttpPostedFileBase data)
        {
            var result = new AjaxResult();

            var path = Server.MapPath("~/upload/");
            using (var file=System.IO.File.Create(path+name+"_"+chunk))
            {
                file.Write(data.InputStream);
            }

            if(chunk==chunks-1)
            {
                using (var file=System.IO.File.Create(path+name))
                {
                    for (int i = 0; i < chunks; i++)
                    {
                        var p = path + name + "_" + i;
                        using(var cf=System.IO.File.OpenRead(p))
                        {
                            file.Write(cf);
                        }
                        System.IO.File.Delete(p);
                    }
                }
            }

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
