using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{

    public class MinimumTreeNode
    {
        public int Cost { get; set; }
        public String Name { get; set; }

        public String ParentName { get; set; }
        
        public List<MinimumTreeNode> Childrens { get; set; }
    }
}
