using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Graph
{
    public class GraphEdge : IComparable
    {
        public GraphNode StartNode { get; set; }
        public GraphNode EndNode { get; set; }
        public double Weights { get; set; }

        public int CompareTo(object obj)
        {
            GraphEdge cobj = obj as GraphEdge;

            return Weights.CompareTo(cobj.Weights);
        }
    }
}
