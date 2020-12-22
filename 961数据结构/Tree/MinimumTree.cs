using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{
    public class MinimumTree
    {
        protected MinimumTreeNode _head = null;
        protected Dictionary<String, MinimumTreeNode> _NodeDic;

        public int TotalCost { get {

                if (_head == null)
                    return 0;

                int cost = 0;

                foreach(var node in _NodeDic)
                {
                    cost += node.Value.Cost;
                }

                return cost;
            } }


        public void Add(MinimumTreeNode node, String parentname)
        {
            if(_head == null)
            {
                _head = node;
                _head.Childrens = null;
                _NodeDic = new Dictionary<string, MinimumTreeNode>();
                _NodeDic.Add(node.Name, node);
            }
            else
            {
                if (!_NodeDic.ContainsKey(parentname))
                    return;

                var pnode = _NodeDic[parentname];
                if (pnode.Childrens == null)
                    pnode.Childrens = new List<MinimumTreeNode>();

                node.Childrens = null;
                pnode.Childrens.Add(node);
                _NodeDic.Add(node.Name, node);
            }
        }
    }
}
