using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Graph
{
    public class PathInfo
    {
        public PathInfo()
        {
            Distance = double.MaxValue;
            TransferNodeIdx = -1;
            TransferNodeName = String.Empty;
        }

        public double Distance { get; set; } //最短距离
        public int TransferNodeIdx { get; set; } //中转顶点
        public String TransferNodeName { get; set; }
    }
}
