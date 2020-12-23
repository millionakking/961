using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{
    public class MinimumTree
    {
        protected MinimumTreeNode _head = null;
        protected Dictionary<String, MinimumTreeNode> _NodeDic;
        protected List<MinimumTreeNode> _NodeList;


        public double TotalCost
        {
            get
            {

                if (_head == null)
                    return 0;

                double cost = 0;

                foreach (var node in _NodeList)
                {
                    cost += node.Cost;
                }

                return cost;
            }
        }

        public MinimumTreeNode[] BuildSequence
        {
            get
            {
                if (_NodeDic == null) return null;

                return _NodeList.ToArray();


            }
        }


        public List<MinimumTreeNode> BSF(MinimumTreeNode root)
        {
            List<MinimumTreeNode> result = new List<MinimumTreeNode>();
            Queue.Queue961<MinimumTreeNode> queue = new _961数据结构.Queue.Queue961<MinimumTreeNode>();

            queue.enqueue(root);

            while (!queue.isEmpty())
            {
                var node = queue.dequeue();
                result.Add(node);
                if (node.Childrens != null)
                    foreach (var cn in node.Childrens)
                        queue.enqueue(cn);
            }

            return result;
        }

        public bool Add(List<Graph.GraphEdge> edges)
        {
            List<MinimumTreeNode> headnodes = new List<MinimumTreeNode>();
            Dictionary<String, MinimumTreeNode> NodeDic = new Dictionary<string, MinimumTreeNode>();

            _NodeList = new List<MinimumTreeNode>();

            foreach (var edge in edges)
            {
                bool bfinds = false;
                bool bfinde = false;
                MinimumTreeNode snode = null;
                if (NodeDic.ContainsKey(edge.StartNode.Name))
                {
                    snode = NodeDic[edge.StartNode.Name];
                    if (snode.Childrens == null)
                        snode.Childrens = new List<MinimumTreeNode>();
                    bfinds = true;
                }
                else
                {
                    snode = new MinimumTreeNode { Cost = 0, Childrens = new List<MinimumTreeNode>(), Name = edge.StartNode.Name, ParentName = string.Empty };
                    NodeDic.Add(snode.Name, snode);
                }

                MinimumTreeNode enode = null;
                if (NodeDic.ContainsKey(edge.EndNode.Name))
                {
                    bfinde = true;
                    enode = NodeDic[edge.EndNode.Name];
                }
                else
                {
                    enode = new MinimumTreeNode { Cost = edge.Weights, Childrens = null, Name = edge.EndNode.Name, ParentName = edge.StartNode.Name };
                    NodeDic.Add(enode.Name, enode);
                }

                if (!bfinds)
                    _NodeList.Add(snode);
                if (!bfinde)
                    _NodeList.Add(enode);

                if (!bfinds && !bfinde)
                    headnodes.Add(snode);

                if (bfinds && bfinde)
                {
                    if (String.IsNullOrEmpty(enode.ParentName))
                    {
                        enode.Cost = edge.Weights;
                        enode.ParentName = edge.StartNode.Name;
                        headnodes.Remove(enode);
                        snode.Childrens.Add(enode);
                    }

                    else if (String.IsNullOrEmpty(snode.ParentName))
                    {
                        snode.Cost = edge.Weights;
                        snode.ParentName = edge.EndNode.Name;
                        headnodes.Remove(snode);
                        if (enode.Childrens == null)
                            enode.Childrens = new List<MinimumTreeNode>();
                        enode.Childrens.Add(snode);
                    }
                    else
                    {
                        MinimumTreeNode pnode = NodeDic[enode.ParentName];
                        MinimumTreeNode cnode = enode;
                        double ccost = cnode.Cost;
                        while (pnode != null)
                        {
                            string parentname = pnode.ParentName;
                            double pcostback = pnode.Cost;
                            pnode.Childrens.Remove(cnode);
                            pnode.ParentName = cnode.Name;
                            pnode.Cost = ccost;
                            ccost = pcostback;
                            if (cnode.Childrens == null)
                                cnode.Childrens = new List<MinimumTreeNode>();
                            cnode.Childrens.Add(pnode);

                            if (!string.IsNullOrEmpty(parentname))
                            {
                                cnode = pnode;
                                pnode = NodeDic[pnode.ParentName];
                            }
                            else
                            {
                                headnodes.Remove(pnode);
                                pnode = null;
                            }
                        }

                        snode.Childrens.Add(enode);
                        enode.Cost = edge.Weights;
                        enode.ParentName = edge.StartNode.Name;
                    }

                }else if(bfinde && !bfinds)
                {
                    snode.Cost = edge.Weights;
                    snode.ParentName = edge.EndNode.Name;
                    if (enode.Childrens == null)
                        enode.Childrens = new List<MinimumTreeNode>();
                    enode.Childrens.Add(snode);
                }
                else
                {
                    enode.Cost = edge.Weights;
                    enode.ParentName = edge.StartNode.Name;
                    snode.Childrens.Add(enode);
                }


            }

            _NodeDic = NodeDic;
            _head = headnodes[0];

            return true;
        }

        public bool Add(MinimumTreeNode node, String parentname)
        {
            if (_head == null)
            {
                _head = node;
                _head.Childrens = null;
                _NodeDic = new Dictionary<string, MinimumTreeNode>();
                _NodeList = new List<MinimumTreeNode>();
                _NodeDic.Add(node.Name, node);
                _NodeList.Add(node);
            }
            else
            {
                if (!_NodeDic.ContainsKey(parentname))
                    return false;

                var pnode = _NodeDic[parentname];
                if (pnode.Childrens == null)
                    pnode.Childrens = new List<MinimumTreeNode>();

                node.Childrens = null;
                pnode.Childrens.Add(node);
                _NodeDic.Add(node.Name, node);
                _NodeList.Add(node);
            }

            return true;
        }
    }
}
