using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.Flow
{
    public class EndNode
    {
        private List<Node> _parents = null;
        public List<Node> Parents
        {
            get
            {
                if (_parents == null)
                    _parents = new List<Node>();
                return _parents;
            }
        }
    }
}