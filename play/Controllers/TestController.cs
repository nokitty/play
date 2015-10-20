using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Transactions;

namespace play.Controllers
{
    public class TestController : ControllerBase
    {
        //
        // GET: /EFCacheTest/

        public ActionResult EFCacheTest()
        {
            DB.Users.Add(new Models.User { Name = "89" });
            DB.SaveChanges();
            var user = DB.Users.Where(u => u.Name == "89").FirstOrDefault();
            return Content("");
        }

        public ActionResult TransactionTest()
        {
            using(var transaction=new TransactionScope())
            {
                transaction.Complete();
            }
            return View();
        }

        public ActionResult Static()
        {
            var a = new int[4];
            return Content("xml");
        }

        public ActionResult AdminUser()
        {
            var user = DB.AdminUsers.Where(u => u.Username == "23").FirstOrDefault();
            return Content("ok");
        }

        public ActionResult Upload(string filename,int chunk,int chunks,HttpPostedFileBase file)
        {
            var result = new AjaxResult();
            using (var fs = System.IO.File.Create(string.Format("~/temp/{0)_{1}", filename, chunk).MapPath()))
            {
                fs.Write(file.InputStream);
            }

            if (chunk == chunks - 1)
            {
                var mergePath = string.Format("~/temp/{0}", filename).MapPath();
                using (var fs = System.IO.File.Create(mergePath))
                {
                    for (int i = 0; i < chunks; i++)
                    {
                        var chunkPath = string.Format("~/temp/{0)_{1}", filename, i).MapPath();
                        using (var cf = System.IO.File.OpenRead(chunkPath))
                        {
                            fs.Write(cf);
                        }
                        System.IO.File.Delete(chunkPath);
                    }
                    result.Data = filename;
                }

                System.IO.File.Delete(mergePath);
            }
            return Json(result);
        }
    }
}
