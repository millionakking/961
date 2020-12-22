using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Graph
{
    public class GraphEdge
    {
        public GraphNode StartNode { get; set; }
        public GraphNode EndNode { get; set; }
        public int Weights { get; set; }
    }
}
