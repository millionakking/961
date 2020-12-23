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


        protected double[][] _Edges = null;

        public override GraphEdge[] AllEdges
        {
            get
            {

                if (_Edges == null)
                    return null;

                List<GraphEdge> edges = new List<GraphEdge>();

                for (int i = 0; i < NodesCount; i++)
                {
                    for (int j = 0; j < NodesCount; j++)
                    {
                        if (_Edges[i][j] >= 0)
                        {
                            edges.Add(new GraphEdge { StartNode = _nodesarray[i], EndNode = _nodesarray[j], Weights = _Edges[i][j] });
                        }
                    }
                }

                return edges.ToArray();

            }
        }

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


            _Edges = new double[nodes.Length][];
            for (int i = 0; i < _Edges.Length; i++)
            {
                _Edges[i] = new double[nodes.Length];
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

            double[] mini_costs = new double[NodesCount]; //到最小生成树最小代价
            int[] node_v = new int[NodesCount]; //最小生成树顶点
            int[] edge_n = new int[NodesCount]; //最短边

            for (int i = 0; i < NodesCount; i++)
            {
                mini_costs[i] = double.MaxValue; //Max代表不连通
                node_v[i] = 0; //0代表当前未放入最小生成树中
                edge_n[i] = -1; //当前i节点的最短路径是和谁产生的
            }

            MinimumTree tree = new MinimumTree();

            node_v[nodeidx] = 1; //初始顶点放入最小生成树中

            tree.Add(new MinimumTreeNode { Cost = 0, Name = _nodesarray[nodeidx].Name, ParentName = string.Empty }, "");

            for (int i = 0; i < NodesCount; i++)
            {
                double cost = getWeight(nodeidx, i);
                if (cost >= 0)
                {
                    mini_costs[i] = cost;
                    edge_n[i] = nodeidx;
                }
            }

            for (int i = 0; i < NodesCount; i++)
            {
                double minCost = double.MaxValue;
                int minIdx = -1;
                for (int j = 0; j < NodesCount; j++) //找当前最小节点
                {
                    if (mini_costs[j] < minCost && node_v[j] == 0)
                    {
                        minIdx = j;
                        minCost = mini_costs[j];
                    }
                }

                if (minIdx < 0) //没找着，继续
                    continue;

                node_v[minIdx] = 1; //加入最小生成树
                tree.Add(new MinimumTreeNode { Cost = minCost, Name = _nodesarray[minIdx].Name, ParentName = _nodesarray[edge_n[minIdx]].Name }, _nodesarray[edge_n[minIdx]].Name);

                for (int j = 0; j < NodesCount; j++) //更新当前最小生成树到其他节点的最小代价
                {
                    if (node_v[j] == 0)
                    {
                        double cost = getWeight(minIdx, j);
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

        public override MinimumTree miniGeneralTree_Kruskal()
        {
            int[] vnodeset = new int[NodesCount]; //存放定点联通情况
            for (int i = 0; i < vnodeset.Length; i++) //初始化V集合为空
            {
                vnodeset[i] = i;
            }

            GraphEdge[] edges = AllEdges;
            Sort<GraphEdge>.MergeSort(edges); //对边排序

            int edgeidx = 0; //边的索引
            int curMiniTreeEdgeCount = 0;

            MinimumTree tree = new MinimumTree();

            List<GraphEdge> selectededges = new List<GraphEdge>();

            while (curMiniTreeEdgeCount < NodesCount - 1)
            {
                var starnodetidx = _nodes[edges[edgeidx].StartNode.Name];
                var Endnodetidx = _nodes[edges[edgeidx].EndNode.Name];

                int setidx1 = vnodeset[starnodetidx];
                int setidx2 = vnodeset[Endnodetidx];

                if (setidx1 != setidx2)
                {
                    selectededges.Add(edges[edgeidx]);
                    curMiniTreeEdgeCount++;
                    for (int i = 0; i < NodesCount; i++)
                    {
                        if (vnodeset[i] == setidx2)
                            vnodeset[i] = setidx1;
                    }
                }

                edgeidx++;
            }

            tree.Add(selectededges);

            return tree;

        }

        public override double getWeight(int startidx, int endidx)
        {

            if (startidx < 0 || startidx >= NodesCount)
                return -1;

            if (endidx < 0 || endidx >= NodesCount)
                return -1;

            return _Edges[startidx][endidx];
        }


        public override List<GraphEdge> MiniDistance_BSF(int startidx, int destidx)
        {
            if (startidx < 0 && startidx >= NodesCount)
                return new List<GraphEdge>();

            if (destidx < 0 && destidx >= NodesCount)
                return new List<GraphEdge>();

            if (startidx == destidx)
                return new List<GraphEdge>();

            Queue.Queue961<int> queue = new Queue961<int>();
            queue.enqueue(startidx);

            int[] visitednodes = new int[NodesCount];
            int[] parentpathnodes = new int[NodesCount];
            int[] nodedistance = new int[NodesCount];

            for (int i = 0; i < NodesCount; i++)
            {
                nodedistance[i] = int.MaxValue;
                visitednodes[i] = 0;
                parentpathnodes[i] = -1;
            }

            visitednodes[startidx] = 1;
            nodedistance[startidx] = 0;

            while (!queue.isEmpty())
            {
                var curidx = queue.dequeue();
                var neighbourenodes = getNeighbourNodes(curidx);
                for (int i = 0; i < neighbourenodes.Count; i++)
                {
                    int nodeidx = neighbourenodes[i];
                    if (visitednodes[nodeidx] == 0)
                    {
                        visitednodes[nodeidx] = 1; //已访问
                        nodedistance[nodeidx] = nodedistance[curidx] + 1;
                        parentpathnodes[nodeidx] = curidx;

                        if (nodeidx == destidx) //找到跳出循环
                        {
                            queue.clear();
                            break;
                        }

                        queue.enqueue(nodeidx);
                    }
                }
            }


            List<GraphEdge> edges = new List<GraphEdge>();
            int pathendidx = destidx;
            while(parentpathnodes[pathendidx] >= 0)
            {
                GraphEdge edge = new GraphEdge { Weights = 1, StartNode = _nodesarray[parentpathnodes[pathendidx]], EndNode = _nodesarray[pathendidx] };
                pathendidx = parentpathnodes[pathendidx];
                edges.Insert(0, edge);
            }

            return edges;
        }

        public override FloyPath MiniDistance_Floyd()
        {
            PathInfo[][] floydPathInfos = initFloyPath();

            for(int k=0;k<NodesCount;k++)
            {
                for(int i = 0;i<NodesCount;i++)
                    for(int j=0;j<NodesCount;j++)
                        if(floydPathInfos[i][k].Distance != Double.MaxValue && floydPathInfos[k][j].Distance != Double.MaxValue && floydPathInfos[i][j].Distance > floydPathInfos[i][k].Distance + floydPathInfos[k][j].Distance)
                        {
                            floydPathInfos[i][j].Distance = floydPathInfos[i][k].Distance + floydPathInfos[k][j].Distance;
                            floydPathInfos[i][j].TransferNodeIdx = k;
                            floydPathInfos[i][j].TransferNodeName = _nodesarray[k].Name;
                        }
            }

            return new FloyPath(floydPathInfos,_nodesarray);
        }

        protected override PathInfo[][] initFloyPath()
        {
            PathInfo[][] floydPathInfos = new PathInfo[NodesCount][];
            for(int i=0;i<NodesCount;i++)
            {
                floydPathInfos[i] = new PathInfo[NodesCount];
                for(int j=0;j< NodesCount;j++)
                {
                    floydPathInfos[i][j] = new PathInfo();
                    if(_Edges[i][j] >= 0)
                    {
                        floydPathInfos[i][j].Distance = _Edges[i][j];
                    }

                    if(i == j)
                    {
                        floydPathInfos[i][j].Distance = 0;
                    }
                }
            }

            return floydPathInfos;
        }

        public override DijkstraPath MiniDistance_Dijkstra(int startidx)
        {
            if (startidx < 0 && startidx >= NodesCount)
                return null;

            PathInfo[] pathinfo = new PathInfo[NodesCount];
            int[] nodev = new int[NodesCount];
            for (int i  = 0;i<NodesCount;i++)
            {
                pathinfo[i] = new PathInfo();

                if (_Edges[startidx][i] >= 0)
                    pathinfo[i].Distance = _Edges[startidx][i];

                if (i == startidx)
                    pathinfo[i].Distance = 0;

                nodev[i] = 0;
            }

            nodev[startidx] = 1;

            for(int i=0;i<NodesCount;i++)
            {
                double mindis = double.MaxValue;
                int minnodeidx = -1;
                for(int j=0;j<NodesCount;j++) //找到当前最小边
                {
                    if(nodev[j]  == 0 && pathinfo[j].Distance < mindis)
                    {
                        mindis = pathinfo[j].Distance;
                        minnodeidx = j;
                    }
                }

                if (minnodeidx < 0) //全部找到，不用找了
                    break;

                nodev[minnodeidx] = 1;
                for(int j=0;j<NodesCount;j++)
                {
                    double distance_s_to_m = pathinfo[minnodeidx].Distance;
                    double distance_m_to_j = _Edges[minnodeidx][j] >= 0 ? _Edges[minnodeidx][j] : double.MaxValue;
                    if(distance_m_to_j != double.MaxValue && pathinfo[j].Distance > distance_s_to_m + distance_m_to_j)
                    {
                        pathinfo[j].Distance = distance_s_to_m + distance_m_to_j;
                        pathinfo[j].TransferNodeIdx = minnodeidx;
                        pathinfo[j].TransferNodeName = _nodesarray[minnodeidx].Name;
                    }
                }

            }


            return new DijkstraPath(pathinfo, Nodes, startidx);


        }
    }
}
