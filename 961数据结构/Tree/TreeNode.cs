using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{
    public class TreeNode : IComparable

    {
        public TreeNode()
        {
            nodeValue = 0;
            childNodes = new List<TreeNode>();
        }
        public int nodeValue { get; set; }
        public List<TreeNode> childNodes { get; set; }

        public int CompareTo(object obj)
        {
            int cpval = (int)obj;
            if (nodeValue > cpval)
                return 1;
            if (nodeValue < cpval)
                return -1;

            return 0;
        }
    }
}
