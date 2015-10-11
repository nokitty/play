using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class Job1:Job
    {

        public Job1(TimeSpan interval, object param) : base(interval,param) { }

        public override void Excute(object param)
        {
            System.Console.WriteLine(param);
        }
    }
}
