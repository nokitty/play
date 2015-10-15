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

    }
}
