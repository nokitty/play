using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        virtual public User User { get; set; }
        public int RoleID { get; set; }
        virtual public Role Role { get; set; }
    }
}