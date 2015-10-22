using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new { id = 10, age = 20 };
            foreach (var item in obj.GetType().GetProperties())
            {
                var str = string.Format("name={0},value={1}", item.Name, item.GetValue(obj,null));
                Console.WriteLine(str);
            }
            Console.Read();
        }
    }
}
