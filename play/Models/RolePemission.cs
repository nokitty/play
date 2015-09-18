using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.Models
{
    public class RolePemission
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        virtual public Role Role { get; set; }
        public int PermissionID { get; set; }
        virtual public Permission Permission { get; set; }
        public byte Value { get; set; }
    }
}