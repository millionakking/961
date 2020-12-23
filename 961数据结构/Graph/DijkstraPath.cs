using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Graph
{
    public class DijkstraPath
    {
        public PathInfo [] Paths { get; set; }
        public GraphNode [] Nodes { get; set; }

        public int StartIdx { get; set; }
        public DijkstraPath(PathInfo[] paths, GraphNode[] nodes, int startidx)
        {
            Paths = paths;
            Nodes = nodes;
            StartIdx = startidx;
        }

        public int NodeCounts
        {
            get
            {
                if (Nodes == null)
                    return 0;

                return Nodes.Length;
            }
        }

        public Double getShortDistance(int destidx)
        {
            if (Paths == null)
                return -1;

            if (destidx < 0 || destidx >= NodeCounts)
                return -1;

            return Paths[destidx].Distance;
        }

        public List<GraphEdge> getShortPath(int destidx)
        {
            if (Paths == null)
                return null;

            if (destidx < 0 || destidx >= NodeCounts)
                return null;

            List<GraphEdge> edges = new List<GraphEdge>();

            int curidx = destidx;
            while (curidx >= 0)
            {
                int transidx = Paths[curidx].TransferNodeIdx;
                if (transidx >= 0)
                {
                    edges.Insert(0, new GraphEdge { Weights = Paths[transidx].Distance, StartNode = Nodes[transidx], EndNode = Nodes[curidx] });
                }
                else
                {
                    edges.Insert(0, new GraphEdge { Weights = Paths[StartIdx].Distance, EndNode = Nodes[curidx], StartNode = Nodes[StartIdx] });
                }
                curidx = transidx;
            }


            return edges;
        }
    }
}
