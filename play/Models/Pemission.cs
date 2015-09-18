using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.Models
{
    public class Permission
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int ParentID { get; set; }
    }
}