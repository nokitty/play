using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flow
{
    public class BeginNode : NodeBase
    {
        private List<Node> _children;
    
        public List<Node> Children
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public void Submit()
        {
            throw new System.NotImplementedException();
        }
    }
}
