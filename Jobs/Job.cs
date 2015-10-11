using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public abstract class Job
    {
        object _param = null;
        public Worker Parent { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interval">执行时间间隔，TimeSpan.Zero为只执行一次</param>
        public Job(TimeSpan interval,object param)
        {
            Interval = interval;
            LastExcute = DateTime.MinValue;
            _param = param;
        }

        public DateTime LastExcute { set; get; }
        public  bool IsProcessing { set; get; }
        public TimeSpan Interval { set; get; }
        abstract public void Excute(object param);
        public void ExcuteCore()
        {
            IsProcessing = true;
            Excute(_param);
            LastExcute = DateTime.Now;
            IsProcessing = false;
            if(Interval==TimeSpan.Zero)
            {
                Parent.Jobs.Remove(this);
            }
        }
    }
}
