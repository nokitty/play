﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace play.Controllers
{
    public class ModalController : Controller
    {
        //
        // GET: /Modal/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form()
        {
            return PartialView();
        }

    }
}
