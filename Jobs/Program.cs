using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            //添加新工作
            worker.Add(new Job1(TimeSpan.FromSeconds(1), "job1"));
            worker.Add(new Job1(TimeSpan.FromSeconds(2), "job2"));
            worker.Add(new Job1(TimeSpan.FromSeconds(3), "job3"));
            worker.Add(new Job3());

            worker.StartAsync();
        }
    }
}
