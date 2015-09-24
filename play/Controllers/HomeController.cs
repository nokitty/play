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
