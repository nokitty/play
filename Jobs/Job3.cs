using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class Job3:Job
    {
        public Job3() : base(TimeSpan.FromSeconds(1),null) { }
        public override void Excute(object param)
        {
            var worker = new Worker();
            worker.Add(new Job1(TimeSpan.Zero, "sub worker job1"));
            worker.Start();
        }
    }
}
