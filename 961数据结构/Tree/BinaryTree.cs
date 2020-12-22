using _961数据结构.Queue;
using _961数据结构.Stack;
using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{
    public class BinaryTree
    {
        protected BinaryTreeNode _head = null;

        public virtual void Construct(int[] vals)
        {
            BinaryTreeNode[] nodes = new BinaryTreeNode[vals.Length];
            for (int i = 0; i < vals.Length; i++)
            {
                nodes[i] = new BinaryTreeNode();
                nodes[i].nodeValue = vals[i];
            }

            for (int i = 1; i < vals.Length / 2 + 1; i++)
            {
                if (i * 2 - 1 < vals.Length)
                {
                    nodes[i - 1].leftChildNode = nodes[i * 2 - 1];
                    if (i * 2 < vals.Length)
                    {
                        nodes[i - 1].rightChildNode = nodes[i * 2 ];

                    }
                    else
                    {
                        nodes[i - 1].rightChildNode = null;
                    }
                }
                else
                {
                    nodes[i - 1].leftChildNode = null;
                    nodes[i - 1].rightChildNode = null;
                }
            }

            _head = nodes[0];
        }

        public virtual void ConstructHuffmanTree(int [] vals)
        {
            if (vals == null || vals.Length == 0)
                return;

            List<IComparable> nodes = new List<IComparable>();
            for (int i = 0; i < vals.Length; i++)
            {
                BinaryTreeNode node = new BinaryTreeNode();
                node.nodeValue = vals[i];
                nodes.Add(node);
            }

            while(nodes.Count > 1)
            {
                Sort<IComparable>.InsertionSort(nodes);
                BinaryTreeNode node = new BinaryTreeNode();
                BinaryTreeNode node1 = nodes[0] as BinaryTreeNode;
                BinaryTreeNode node2 = nodes[1] as BinaryTreeNode;
                nodes.RemoveRange(0, 2);
                node.nodeValue = node1.nodeValue + node2.nodeValue;
                node.leftChildNode = node1;
                node.rightChildNode = node2;
                nodes.Insert(0, node);
            }

            _head = nodes[0] as BinaryTreeNode;

        }

        public List<BinaryTreeNode> DLRStackSequence()
        {
            if (_head == null)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                return null;

            Stack961<BinaryTreeNode> stack = new Stack961<BinaryTreeNode>();
           
            List<BinaryTreeNode> sequence = new List<BinaryTreeNode>();
            BinaryTreeNode node = _head;
            while (node != null || !stack.isEmpty())
            {
                while(node!=null)
                {
                    sequence.Add(node);
                    stack.push(node);
                    node = node.leftChildNode;
                }

                if(!stack.isEmpty())
                {
                    node = stack.pop();
                    node = node.rightChildNode;
                }
            }

            return sequence;
        }

        public List<BinaryTreeNode> LDRStackSequence()
        {
            if (_head == null)
                return null;

            Stack961<BinaryTreeNode> stack = new Stack961<BinaryTreeNode>();

            List<BinaryTreeNode> sequence = new List<BinaryTreeNode>();
            BinaryTreeNode node = _head;
            while (node != null || !stack.isEmpty())
            {
                while (node != null)
                {
                    stack.push(node);
                    node = node.leftChildNode;
                }

                if (!stack.isEmpty())
                {
                    node = stack.pop();
                    sequence.Add(node);
                    node = node.rightChildNode;
                }
            }

            return sequence;
        }

        public List<BinaryTreeNode> LevelOrder()
        {
            if (_head == null)
                return null;

            Queue961<BinaryTreeNode> queue = new Queue961<BinaryTreeNode>();
            List<BinaryTreeNode> sequence = new List<BinaryTreeNode>();
            queue.enqueue(_head);

            while(!queue.isEmpty())
            {
                var node = queue.dequeue();
                if (node.leftChildNode != null)
                    queue.enqueue(node.leftChildNode);
                if (node.rightChildNode != null)
                    queue.enqueue(node.rightChildNode);
                sequence.Add(node);
            }

            return sequence;

        }

        public List<BinaryTreeNode> LRDStackSequence()
        {
            if (_head == null)
                return null;

            Stack961<BinaryTreeNode> stack = new Stack961<BinaryTreeNode>();

            List<BinaryTreeNode> sequence = new List<BinaryTreeNode>();
            BinaryTreeNode node = _head;
            while (node != null || !stack.isEmpty())
            {
                while (node != null)
                {
                    stack.push(node);
                    sequence.Insert(0, node);
                    node = node.rightChildNode;

                }

                if (!stack.isEmpty())
                {
                    node = stack.pop();
                    node = node.leftChildNode;
                }
            }

            return sequence;
        }

        public List<BinaryTreeNode> DLRSequence()
        {
            List<BinaryTreeNode> sequence = new List<BinaryTreeNode>();
            DLRRecursive(_head, sequence);
            return sequence;
        }

        public List<BinaryTreeNode> LDRSequence()
        {
            List<BinaryTreeNode> sequence = new List<BinaryTreeNode>();
            LDRRecursive(_head, sequence);
            return sequence;
        }

        public List<BinaryTreeNode> LRDSequence()
        {
            List<BinaryTreeNode> sequence = new List<BinaryTreeNode>();
            LRDRecursive(_head, sequence);
            return sequence;
        }

        BinaryTreeNode DLRFindRecursive(BinaryTreeNode node, int val)
        {
            if (node != null)
            {
                if (node.nodeValue == val)
                    return node;
                if (DLRFindRecursive(node.leftChildNode, val) != null)
                    return node.leftChildNode;
                if (DLRFindRecursive(node.rightChildNode, val) != null)
                    return node.leftChildNode;
            }

            return null;
        }


        void DLRRecursive(BinaryTreeNode node, List<BinaryTreeNode> sequence)
        {
            if (node != null)
            {
                sequence.Add(node);
                DLRRecursive(node.leftChildNode, sequence);
                DLRRecursive(node.rightChildNode, sequence);
            }
        }

        void LDRRecursive(BinaryTreeNode node, List<BinaryTreeNode> sequence)
        {
            if (node != null)
            {
                LDRRecursive(node.leftChildNode, sequence);
                sequence.Add(node);
                LDRRecursive(node.rightChildNode, sequence);
            }
        }

        public int Height()
        {
            return Height(_head);
        }

        protected int Height(BinaryTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int left = Height(node.leftChildNode);
            int right = Height(node.rightChildNode);

            //平衡因子
            node.BlanceFacor = left - right;

            return Math.Max(left, right) + 1;
        }

        public bool isBalance()
        {
            int height;
            return isBalance(_head, out height);
        }

        protected bool isBalance(BinaryTreeNode node, out int height)
        {
            if (node == null)
            {
                height = 0;
                return true;
            }
            int leftheight, rightheight;
            bool leftok, rightok;
            leftok = isBalance(node.leftChildNode,out leftheight);
            if (!leftok)
            {
                height = -1;
                return false;
            }

            rightok = isBalance(node.rightChildNode,out rightheight);
            if (!rightok)
            {
                height = -1;
                return false;
            }


            height = Math.Max(leftheight, rightheight) + 1;

            int diff = Math.Abs(leftheight - rightheight);
            if(diff <= 1)
            {
                return true;
            }

            return false;
        }

        void LRDRecursive(BinaryTreeNode node, List<BinaryTreeNode> sequence)
        {
            if (node != null)
            {
                LRDRecursive(node.leftChildNode, sequence);
                LRDRecursive(node.rightChildNode, sequence);
                sequence.Add(node);
            }
        }
    }
}
