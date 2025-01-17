﻿using _961数据结构.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Graph
{
    public abstract class Graph961
    {
        protected Dictionary<String, int> _nodes = null;
        protected GraphNode[] _nodesarray = null;
        public int NodesCount { get { return _nodesarray == null ? 0 : _nodesarray.Length; } }

        public GraphNode[] Nodes { get { return _nodesarray; } }

        public abstract List<GraphNode> DFS(int nodeidx);
        public abstract List<GraphNode> DFS();
        public abstract List<GraphNode> BFS(int nodeidx);
        public abstract List<GraphNode> BFS();

        public abstract MinimumTree miniGeneralTree_Prim(int nodeidx);
        public abstract MinimumTree miniGeneralTree_Kruskal();

        public abstract GraphEdge[] AllEdges { get; }

        //仅适用于有向无权图
        public abstract List<GraphEdge> MiniDistance_BSF(int startidx, int destidx);
        public abstract FloyPath MiniDistance_Floyd();

        public abstract DijkstraPath MiniDistance_Dijkstra(int startidx);

        protected abstract PathInfo[][] initFloyPath();

        public abstract double getWeight(int startidx, int endidx);
    }
}
