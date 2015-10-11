using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BackgroundWorker
{
    public class Worker
    {
        List<Job> _jobs = new List<Job>();
        public List<Job> Jobs
        {
            get
            {
                return _jobs;
            }
        }

        public void Add(Job job)
        {
            job.Parent = this;
            Jobs.Add(job);
        }
        public void Start()
        {
            while (true)
            {
                foreach (var job in Jobs)
                {
                    if(job.IsProcessing==false && job.LastExcute+job.Interval<DateTime.Now  )
                    {
                        var t = new Thread(new ThreadStart(job.ExcuteCore));
                        t.IsBackground = true;
                        t.Start();
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}
