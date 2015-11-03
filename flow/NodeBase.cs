using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flow
{
    public class NodeBase
    {
        public int ID { get; set; }

        public NodeStates State
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        virtual public void Start()
        {
            State = NodeStates.InProcess;
        }
    }
}
