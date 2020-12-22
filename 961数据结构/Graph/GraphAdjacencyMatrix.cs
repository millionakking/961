using _961数据结构.Queue;
using _961数据结构.Stack;
using _961数据结构.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Graph
{
    class GraphAdjacencyMatrix : Graph961
    {


        protected int[][] _Edges = null;


        public GraphAdjacencyMatrix(GraphNode[] nodes, GraphEdge[] edges)
        {
            if (nodes == null || nodes.Length == 0)
                return;

            _nodesarray = nodes;

            _nodes = new Dictionary<string, int>();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!_nodes.ContainsKey(nodes[i].Name))
                    _nodes.Add(nodes[i].Name, i);
            }


            _Edges = new int[nodes.Length][];
            for (int i = 0; i < _Edges.Length; i++)
            {
                _Edges[i] = new int[nodes.Length];
                for (int j = 0; j < _Edges.Length; j++)
                {
                    _Edges[i][j] = -1;
                }
            }

            foreach (var edge in edges)
            {
                int startidx = -1;
                int endidx = -1;
                if (_nodes.ContainsKey(edge.StartNode.Name))
                    startidx = _nodes[edge.StartNode.Name];
                if (_nodes.ContainsKey(edge.EndNode.Name))
                    endidx = _nodes[edge.EndNode.Name];

                if (startidx == -1 || endidx == -1)
                {
                    continue;
                }

                _Edges[startidx][endidx] = edge.Weights;
            }

        }

        public override List<GraphNode> BFS(int nodeidx)
        {
            int[] visitedflag = new int[NodesCount];
            for (int i = 0; i < NodesCount; i++)
                visitedflag[i] = 0;

            return BFS(nodeidx, visitedflag);
        }

        protected List<GraphNode> BFS(int nodeidx, int[] visitedflag)
        {
            if (nodeidx < 0 || nodeidx >= NodesCount || visitedflag[nodeidx] == 1)
                return null;

            Queue961<int> queue = new Queue961<int>();
            int curidx = nodeidx;
            queue.enqueue(curidx);

            List<GraphNode> result = new List<GraphNode>();

            while (!queue.isEmpty())
            {
                curidx = queue.dequeue();
                if (visitedflag[curidx] == 1)
                    continue;
                visitedflag[curidx] = 1;
                result.Add(_nodesarray[curidx]);
                List<int> neighbours = getNeighbourNodes(curidx);

                for (int i = 0; i < neighbours.Count; i++)
                {
                    if (visitedflag[neighbours[i]] == 0)
                    {
                        queue.enqueue(neighbours[i]);
                    }
                }
            }

            return result;
        }

        protected List<int> getNeighbourNodes(int nodeidx)
        {
            if (nodeidx < 0 || nodeidx >= NodesCount)
                return null;

            List<int> neighbours = new List<int>();
            for (int i = 0; i < NodesCount; i++)
            {
                if (_Edges[nodeidx][i] > 0)
                    neighbours.Add(i);
            }

            return neighbours;
        }

        public override List<GraphNode> DFS(int nodeidx)
        {
            int[] visitedflag = new int[NodesCount];
            for (int i = 0; i < NodesCount; i++)
                visitedflag[i] = 0;

            return DFS(nodeidx, visitedflag);
        }

        protected List<GraphNode> DFS(int nodeidx, int[] visitedflag)
        {
            if (nodeidx < 0 || nodeidx >= NodesCount || visitedflag[nodeidx] == 1)
                return null;


            Stack961<int> stack = new Stack961<int>();

            GraphNode node = _nodesarray[nodeidx];
            int curidx = nodeidx;



            List<GraphNode> result = new List<GraphNode>();
            List<int> neighbours;

            while (!stack.isEmpty() || curidx >= 0)
            {
                while (curidx >= 0)
                {
                    stack.push(curidx);
                    result.Add(node);
                    visitedflag[curidx] = 1;

                    neighbours = getNeighbourNodes(curidx);
                    node = null;
                    curidx = -1;
                    for (int i = 0; i < neighbours.Count; i++)
                    {
                        if (visitedflag[neighbours[i]] == 0)
                        {
                            curidx = neighbours[i];
                            node = _nodesarray[curidx];
                        }
                    }
                }

                int popidx = stack.pop();
                neighbours = getNeighbourNodes(popidx);
                for (int i = 0; i < neighbours.Count; i++)
                {
                    if (visitedflag[neighbours[i]] == 0)
                    {
                        curidx = neighbours[i];
                        node = _nodesarray[curidx];
                    }
                }
            }

            return result;

        }

        public override List<GraphNode> DFS()
        {
            int[] visitedflag = new int[NodesCount];
            for (int i = 0; i < NodesCount; i++)
                visitedflag[i] = 0;

            List<GraphNode> result = new List<GraphNode>();

            for (int i = 0; i < NodesCount; i++)
            {
                var rs1 = DFS(i, visitedflag);
                if (rs1 != null && rs1.Count > 0)
                {
                    result.AddRange(rs1);
                }
            }

            return result;
        }

        public override List<GraphNode> BFS()
        {
            int[] visitedflag = new int[NodesCount];
            for (int i = 0; i < NodesCount; i++)
                visitedflag[i] = 0;

            List<GraphNode> result = new List<GraphNode>();

            for (int i = 0; i < NodesCount; i++)
            {
                var rs1 = BFS(i, visitedflag);
                if (rs1 != null && rs1.Count > 0)
                {
                    result.AddRange(rs1);
                }
            }

            return result;
        }

        public override MinimumTree miniGeneralTree_Prim(int nodeidx)
        {
            if (nodeidx < 0 || nodeidx >= NodesCount)
                return null;

            int[] mini_costs = new int[NodesCount]; //到最小生成树最小代价
            int[] node_v = new int[NodesCount]; //最小生成树顶点
            int[] edge_n = new int[NodesCount]; //最短边

            for(int i =0;i<NodesCount;i++)
            {
                mini_costs[i] = int.MaxValue; //Max代表不连通
                node_v[i] = 0; //0代表当前未放入最小生成树中
                edge_n[i] = -1; //当前i节点的最短路径是和谁产生的
            }

            MinimumTree tree = new MinimumTree();

            node_v[nodeidx] = 1; //初始顶点放入最小生成树中

            tree.Add(new MinimumTreeNode { Cost = 0, Name = _nodesarray[nodeidx].Name }, "");

            for(int i=0;i<NodesCount;i++)
            {
                int cost = getWeight(nodeidx, i);
                if(cost>=0)
                {
                    mini_costs[i] = cost;
                    edge_n[i] = nodeidx;
                }
            }

            for(int i = 0;i<NodesCount;i++)
            {
                int minCost = int.MaxValue;
                int minIdx = -1;
                for(int j =0;j<NodesCount;j++) //找当前最小节点
                {
                    if(mini_costs[j] < minCost && node_v[j] == 0)
                    {
                        minIdx = j;
                        minCost = mini_costs[j];
                    }
                }

                if (minIdx < 0) //没找着，继续
                    continue;

                node_v[minIdx] = 1; //加入最小生成树
                tree.Add(new MinimumTreeNode { Cost = minCost, Name = _nodesarray[minIdx].Name }, _nodesarray[edge_n[minIdx]].Name);

                for (int j=0;j< NodesCount;j++) //更新当前最小生成树到其他节点的最小代价
                {
                    if(node_v[j] == 0 )
                    {
                        int cost = getWeight(minIdx, j);
                        if (cost >= 0 && cost < mini_costs[j]) //更新到最小生成树的代价和边
                        {
                            mini_costs[j] = cost;
                            edge_n[j] = minIdx;
                        }
                    }
                }
            }

            return tree;
        }

        public override MinimumTree miniGeneralTree_Kruskal(int nodeidx)
        {
            throw new NotImplementedException();
        }

        public override int getWeight(int startidx, int endidx)
        {

            if (startidx < 0 || startidx >= NodesCount)
                return -1;

            if (endidx < 0 || endidx >= NodesCount)
                return -1;

            return _Edges[startidx][endidx];
        }
    }
}
