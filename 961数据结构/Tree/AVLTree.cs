using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{
    class AVLTree : BSTTree
    {

        public override bool Insert(BinaryTreeNode node)
        {
            if(_head == null)
            {
                _head = node;
                _head.leftChildNode = null;
                _head.rightChildNode = null;
                return true;
            }

            _head = balanceInsert(_head, node);

            return true;
        }

        public virtual BinaryTreeNode balanceInsert(BinaryTreeNode curnode, BinaryTreeNode newnode)
        {
            if(curnode == null)
            {
                newnode.leftChildNode = null;
                newnode.rightChildNode = null;

                return newnode;
            }

            if (curnode.nodeValue < newnode.nodeValue)
                curnode.rightChildNode = balanceInsert(curnode.rightChildNode, newnode);
            else if(curnode.nodeValue > newnode.nodeValue)
                curnode.leftChildNode = balanceInsert(curnode.leftChildNode, newnode);
            else
                return curnode;


            return reBalane(curnode);
        }

        public virtual BinaryTreeNode balanceDelete(BinaryTreeNode curnode, int val)
        {
            if (curnode == null)
                return curnode;

            if (curnode.nodeValue < val)
                curnode.rightChildNode = balanceDelete(curnode.rightChildNode, val);
            else if (curnode.nodeValue > val)
                curnode.leftChildNode = balanceDelete(curnode.leftChildNode, val);
            else
            {
                if(curnode.leftChildNode == null || curnode.rightChildNode == null)
                {
                    var temp = curnode.leftChildNode == null ? curnode.rightChildNode : curnode.leftChildNode;
                    curnode = temp;
                }
                else
                {
                    BinaryTreeNode replacenode = curnode;
                    while(replacenode.leftChildNode!=null)
                    {
                        replacenode = replacenode.leftChildNode;
                    }
                    curnode.nodeValue = replacenode.nodeValue;
                    curnode.rightChildNode = balanceDelete(curnode.rightChildNode, replacenode.nodeValue);
                }
            }

            if (curnode == null)
                return curnode;

            return reBalane(curnode);
        }

        public override bool DelNode(int nodeval)
        {
            return base.DelNode(nodeval);
        }

        //Balance Factor
        protected int getBF(BinaryTreeNode node)
        {
            if (node == null)
                return 0;

            return Math.Abs(Height(node.leftChildNode) - Height(node.rightChildNode));
        }

        protected BinaryTreeNode LL_right_rotate(BinaryTreeNode node)
        {
            BinaryTreeNode newroot = node.leftChildNode;
            node.leftChildNode = newroot.rightChildNode;
            newroot.rightChildNode = node;
            Height(newroot);
            return newroot;
        }

        protected BinaryTreeNode RR_left_rotate(BinaryTreeNode node)
        {
            BinaryTreeNode newroot = node.rightChildNode;
            node.rightChildNode = newroot.leftChildNode;
            newroot.leftChildNode = node;
            Height(newroot);
            return newroot;
        }

        protected BinaryTreeNode LR_left_right_rotate(BinaryTreeNode node)
        {
            node.leftChildNode = RR_left_rotate(node.leftChildNode);
            return LL_right_rotate(node);
        }

        protected BinaryTreeNode RL_left_right_rotate(BinaryTreeNode node)
        {
            node.rightChildNode = LL_right_rotate(node.rightChildNode);
            return RR_left_rotate(node);
        }

        //node 为当前失衡节点
        protected BinaryTreeNode reBalane(BinaryTreeNode node)
        {
            if (node == null)
                return node;

            Height(node);
            int bf_l = node.leftChildNode == null ? 0 : node.leftChildNode.BlanceFacor;
            int bf_r = node.rightChildNode == null ? 0 : node.rightChildNode.BlanceFacor;

            if (node.BlanceFacor > 1)
            {
                if(bf_l > 0)
                {
                    return LL_right_rotate(node);
                }
                else
                {
                    return LR_left_right_rotate(node);
                }
            }
            else if(node.BlanceFacor < -1)
            {
                if(bf_r > 0)
                {
                    return RL_left_right_rotate(node);
                }
                else
                {
                    return RR_left_rotate(node);
                }
            }

            return node;
        }

    }
}
