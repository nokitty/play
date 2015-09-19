using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using play.Models;

namespace play.Controllers
{
    public class ControllerBase:Controller
    {
        private SchoolContext _db = null;
        public SchoolContext DB
        {
            get
            {
                if (_db == null)
                    _db = new SchoolContext();
                return _db;
            }
        }

        private StoredProcedure _storedProcedure = null;
        public StoredProcedure StoredProcedure
        {
            get
            {
                if (_storedProcedure == null)
                    _storedProcedure = new StoredProcedure(DB);
                return _storedProcedure;
            }
        }
    }
}