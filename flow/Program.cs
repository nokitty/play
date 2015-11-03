using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace flow
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new Node { ID = 1 };
            var n2 = new Node { ID = 2 };
            var n3 = new Node { ID = 3 };
            var n4 = new Node { ID = 4 };
            var n5 = new Node { ID = 5 };
            var n6 = new Node { ID = 6 };
            var n7 = new Node { ID = 7 };
            var n8 = new Node { ID = 8 };
            var n9 = new Node { ID = 9 };
            var n10 = new Node { ID = 10 };

            n1.Children.Add(n2);
            n1.Children.Add(n3);
            n1.Children.Add(n4);

            n2.Children.Add(n5);

            n3.Children.Add(n6);

            n5.Children.Add(n7);
            n6.Children.Add(n7);
            n4.Children.Add(n7);
            n4.Children.Add(n9);

            n7.Children.Add(n8);
            n7.Children.Add(n9);

            n8.Children.Add(n10);
            n9.Children.Add(n10);


            var result = new List<Edge>();
            Make(n1, result);

            result.ForEach(r => Console.WriteLine("begin={0},end={1}", r.Begin, r.End));
            Console.WriteLine(ToString(result));


            Console.WriteLine("/////////////////////////////////");
            var buffer = ToBytes(result);
            Dictionary<int, Node> restore;
            Restore(buffer,out restore);

            var result2 = new List<Edge>();
            Make(restore.First().Value, result2);

            result2.ForEach(r => Console.WriteLine("begin={0},end={1}", r.Begin, r.End));
            Console.WriteLine(ToString(result2));
            
            Console.Read();
        }

        static void Make(Node BeginNode,List<Edge> result)
        {
            if (BeginNode.IsVisited)
                return;
            foreach (var node in BeginNode.Children)
            {
                result.Add(new Edge { Begin = BeginNode.ID, End = node.ID });                
                Make(node, result);
                node.IsVisited = true;
            }
        }

        static string ToString(List<Edge> result)
        {
            var sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.AppendFormat("{0},{1}|", item.Begin, item.End);
            }
            return sb.ToString();
        }

        static byte[] ToBytes(List<Edge> result)
        {
            using (var ms=new MemoryStream())
            {
                var bw = new BinaryWriter(ms);
                bw.Write(result.Count);
                foreach (var item in result)
                {
                    bw.Write(item.Begin);
                    bw.Write(item.End);
                }
                return ms.ToArray();
            }
        }

        static void Restore(byte[] value, out Dictionary<int,Node> nodeList)
        {
            nodeList = new Dictionary<int, Node>();
            using (var ms=new MemoryStream(value))
            {
                var br = new BinaryReader(ms);
                var n = br.ReadInt32();
                for (int i = 0; i < n; i++)
                {
                    var begin = br.ReadInt32();
                    var end = br.ReadInt32();

                    Node beginNode ;
                    if(nodeList.TryGetValue(begin,out beginNode)==false)
                    {
                        beginNode = new Node { ID = begin };
                        nodeList[begin] = beginNode;
                    }


                    Node endNode ;
                    if (nodeList.TryGetValue(end, out endNode) == false)
                    {
                        endNode = new Node { ID = end };
                        nodeList[end] = endNode;
                    }

                    beginNode.Children.Add(endNode);
                }
            }
        }

        class Edge
        {
            public int Begin { get; set; }
            public int End { get; set; }
        }
    }
}
