using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flow
{
    public class Node : NodeBase
    {
        private List<Node> _parents;
        private List<Node> _children;
        public bool IsVisited { get; set; }

        public List<Node> Parents
        {
            get
            {
                if (_parents == null)
                    _parents = new List<Node>();
                return _parents;
            }
        }

        public List<Node> Children
        {
            get
            {
                if (_children == null)
                    _children = new List<Node>();
                return _children;
            }
        }

        /// <summary>
        /// 流程通过，进入下一步
        /// </summary>
       virtual public void Submit()
        {
            throw new System.NotImplementedException();
        }

       /// <summary>
       /// 流程驳回，驳回到指定节点
       /// </summary>
       /// <remarks></remarks>
       public void Refuse(Node toNode)
        {
            throw new System.NotImplementedException();
        }
    }
}
