using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace play.Models
{
    public class Security
    {
        const string SessionKey = "userid";
        const string CookieKey = "login";

        static public bool IsLogin
        {
            get
            {
                if (HttpContext.Current.Session[SessionKey] != null)
                    return true;

                var cookie = HttpContext.Current.Request.Cookies[CookieKey];
                if (cookie == null)
                    return false;

                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket == null || ticket.Expired == true)
                    return false;

                var userData = UserData.Parse(ticket.UserData);
                HttpContext.Current.Session[SessionKey] = userData.ID;
                return true;
            }
        }

        static public User User
        {
            get
            {
                if (IsLogin == false)
                    return null;

                var item = HttpContext.Current.Items["User"];
                if (item != null)
                {
                    return item as User;
                }

                var s = new SchoolContext().Users.Find(HttpContext.Current.Session[SessionKey]);
                HttpContext.Current.Items["User"] = s;
                return s;
            }
        }

        static public bool CheckPermissions(params string[] permissions)
        {
            if (IsLogin==false)
                return false;

            var result = true;
            foreach (var p in permissions)
            {
                var value = false;
                try
                {
                    value = Permissions[p];
                }
                catch { }

                result &= value;
                if (result == false)
                    break;
            }
            return result;
        }

        static Dictionary<string, bool> Permissions
        {
            get
            {
                if (IsLogin == false)
                    return null;

                var item = HttpContext.Current.Items["Permissions"];
                if (item != null)
                {
                    return item as Dictionary<string, bool>;
                }

                var result = new Dictionary<string, bool>();
                var db = new SchoolContext();
                var roles = from ur in db.UserRoles
                            where ur.UserID == User.ID
                            select new { ur.RoleID };

                var permissions = from rp in db.RolePermissions
                                  join r in roles on rp.RoleID equals r.RoleID
                                  select new { rp.PermissionID, rp.Value };

                var r0 = from p in db.Permissions
                         join p1 in permissions on p.ID equals p1.PermissionID
                         group p1 by p.Code into g
                         select new { g.Key, sum = g.Sum(i => i.Value) };


                r0.ToList().ForEach(i =>
                {
                    result.Add(i.Key, i.sum > 0);
                });
                HttpContext.Current.Items["Permissions"] = result;
                return result;
            }
        }

        static public void Login(User user, int timeout = 60*24*15)
        {
            var now = DateTime.Now;
            var expire = now.AddMinutes(timeout);
            var userData = new UserData { ID = user.ID };
            var ticket = new FormsAuthenticationTicket(1, user.ID.ToString(), now, expire, true, userData.ToString());

            var cookie = new HttpCookie(CookieKey);
            cookie.Value = FormsAuthentication.Encrypt(ticket);
            cookie.HttpOnly = true;
            cookie.Expires = expire;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        static public void Logout()
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(CookieKey) { Expires = DateTime.Now.AddDays(-1) });
            HttpContext.Current.Session.Remove(SessionKey);
        }

        public class UserData
        {
            public int ID { get; set; }

            public override string ToString()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }

            static public UserData Parse(string str)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserData>(str);
            }
        }
    }
}