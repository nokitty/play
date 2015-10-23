using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CssSelectorToXPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( Convert("div.fesc .ecs"));
            Console.ReadLine();
        }

        static string Convert(string selector)
        {
            var result = "//";
            //先按照空格分开
            var regex = new Regex(@"\S+");
            var matches= regex.Matches(selector);
            foreach (Match match in matches)
            {
                var node="";
                //节点名，默认*
                var nodeName = "*";
                //筛选条件，默认无
                var predicate = "";
                //按照#，.（点号）分开
                var subRegex = new Regex(@"([#\.\w])([^#\.\s])+");
                var subMatches = subRegex.Matches(match.Value);
                foreach (Match sm in subMatches)
                { 
                    var value=sm.Value;
                    if(value.StartsWith("#"))
                    {
                        predicate += string.Format("@id='{0}' && ", value.Substring(1));
                    }
                    else if(value.StartsWith("."))
                    {
                        predicate += string.Format("contains(@class,'{0}') && ", value.Substring(1));
                    }
                    else
                    {
                        nodeName = value;
                    }
                }
                node = nodeName;
                if(predicate!="")
                {
                    predicate = predicate.Substring(0, predicate.Length - 4);
                    node += string.Format("[{0}]", predicate);
                }
                node += "//";
                result+=node;
            }

            return result;
        }
    }
}
