using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.Flow
{
    public class BeginNode
    {
        private List<Node> _children = null;
        public List<Node> Children
        {
            get
            {
                if (_children == null)
                    _children = new List<Node>();
                return _children;
            }
        }

        public void BeginFlow()
        {

        }
    }
}