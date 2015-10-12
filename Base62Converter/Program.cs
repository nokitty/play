using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base62Converter
{
    class Program
    {
        static string _baseStr = "PLOKMNJIUHBVGYTF0CXDRESZWAQ9630258741zaqwsxedcvfrbgtnhyujmikolp";
        static void Main(string[] args)
        {
            var str = ToString(5684);
            Console.WriteLine(str);
            Console.WriteLine(ToInt32(str));
            Console.Read();
        }

        static string ToString(int value)
        {
            var sb = new StringBuilder();
            while (true)
            {
                var a = value % 62;
                sb.Insert(0, _baseStr.Substring(a, 1));
                value /= 62;

                if (value == 0)
                    break;
            }
            return sb.ToString();
        }

        static int ToInt32(string str)
        {
            var result = 0;
            for (int i = 0, n = str.Length; i < n; i++)
            {
                var pos = _baseStr.IndexOf(str.Substring(i, 1));
                result += (int)(pos * Math.Pow(62, n - 1 - i));
            }
            return result;
        }
    }
}
