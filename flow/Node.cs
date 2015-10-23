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

        public List<Node> Parents
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

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
