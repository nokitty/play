using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBackgrounder;


[assembly: WebActivator.PostApplicationStartMethod(typeof(Background.Setup), "Start")]
[assembly: WebActivator.ApplicationShutdownMethod(typeof(Background.Setup), "Shutdown")]

namespace Background
{
    public class Setup
    {
        static readonly JobManager _jobManager = CreateJobWorkersManager();

        public static void Start()
        {
            _jobManager.Start();
        }

        public static void Shutdown()
        {
            _jobManager.Dispose();
        }

        private static JobManager CreateJobWorkersManager()
        {
            var jobs = new IJob[]
            {
            };

            var coordinator = new WebFarmJobCoordinator(new EntityWorkItemRepository(() => new WorkItemsContext()));
            var manager = new JobManager(jobs, coordinator);
            //manager.Fail(ex => Elmah.ErrorLog.GetDefault(null).Log(new Error(ex)));
            return manager;
        }
    }
}