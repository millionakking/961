using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Graph
{
    public class FloyPath
    {
        public int NodeCounts
        {
            get
            {
                if (PathInfo == null)
                    return 0;

                return PathInfo.Length;
            }
        }

        public PathInfo[][] PathInfo { get; set; }
        public GraphNode[] Nodes { get; set; }
        public FloyPath(PathInfo[][] infos, GraphNode [] nodes)
        {
            PathInfo = infos;
            Nodes = nodes;
        }

        public Double getShortDistance(int startidx, int endidx)
        {
            if (PathInfo == null)
                return -1;

            if (startidx < 0 || startidx >= NodeCounts)
                return -1;

            if (endidx < 0 || endidx >= NodeCounts)
                return -1;

            return PathInfo[startidx][endidx].Distance;
        }

        public List<GraphEdge> getShortPath(int startidx, int endidx)
        {
            if (PathInfo == null)
                return null;

            if (startidx < 0 || startidx >= NodeCounts)
                return null;

            if (endidx < 0 || endidx >= NodeCounts)
                return null;

            List<GraphEdge> edges = new List<GraphEdge>();
            int curidx = endidx;
            while(curidx>=0)
            {
                int transidx = PathInfo[startidx][curidx].TransferNodeIdx;
                if(transidx >= 0)
                {
                    edges.Insert(0, new GraphEdge { Weights = PathInfo[transidx][curidx].Distance, EndNode = Nodes[curidx], StartNode = Nodes[transidx] });
                }
                else
                {
                    edges.Insert(0, new GraphEdge { Weights = PathInfo[startidx][curidx].Distance, EndNode = Nodes[curidx], StartNode = Nodes[startidx] });
                }

                curidx = transidx;
            }


            return edges;
        }
    }
}
