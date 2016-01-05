using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ionic.Zip;

namespace play.Controllers
{
    public class ZipController : Controller
    {
        public ActionResult Index()
        {
            using (var zip = new ZipFile())
            {
                var path = Server.MapPath("~/download");
                var rand = new Random();
                foreach (var item in System.IO.Directory.GetFiles(path))
                {
                    zip.AddFile(item,"/"+rand.Next()+".jpg");
                }
                var stream = new System.IO.MemoryStream();

                zip.Save(stream);

                stream.Position = 0;

                return File(stream, "application/zip", "要下载的文件.zip");
            }
        }

    }
}
