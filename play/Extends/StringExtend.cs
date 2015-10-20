using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


static public class StringExtend
{
    static public string MapPath(this string str)
    {
        return HttpContext.Current.Server.MapPath(str);
    }
}