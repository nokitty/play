using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.Models
{
    public class StoredProcedure
    {
        SchoolContext _db;
        public StoredProcedure(SchoolContext db)
        {
            _db = db;
        }
    }
}