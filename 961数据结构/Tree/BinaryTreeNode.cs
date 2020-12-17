using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{
    public class BinaryTreeNode : IComparable
    {
        public BinaryTreeNode()
        {
            nodeValue = 0;
            leftChildNode = null;
            rightChildNode = null;
        }
        public int nodeValue { get; set; }

        public int BlanceFacor { get; set; }

        public BinaryTreeNode leftChildNode { get; set; }
        public BinaryTreeNode rightChildNode { get; set; }

        public int CompareTo(object obj)
        {
            BinaryTreeNode cpvalnode = obj as BinaryTreeNode;
            if (nodeValue > cpvalnode.nodeValue)
                return 1;
            if (nodeValue < cpvalnode.nodeValue)
                return -1;

            return 0;
        }
    }
}
