using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace play.Flow
{
    public class Node
    {
        private List<Node> _parents=null;
        public List<Node> Parents
        {
            get
            {
                if (_parents == null)
                    _parents = new List<Node>();
                return _parents;
            }
        }

        private List<Node> _children=null;
        public List<Node> Children
        {
            get
            {
                if (_children == null)
                    _children = new List<Node>();
                return _children;
            }
        }
    }
}