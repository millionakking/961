﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{
    public class BSTTree : BinaryTree
    {
        public override void Construct(int[] vals)
        {
            for(int i =0;i<vals.Length;i++)
            {
                Insert(new BinaryTreeNode { leftChildNode = null, nodeValue = vals[i], rightChildNode = null });
            }
        }

        public bool Insert(BinaryTreeNode node)
        {
            if (_head == null)
            {
                _head = node;
                node.leftChildNode = null;
                node.rightChildNode = null;
                return true;
            }

            BinaryTreeNode curnode = _head;
            while(curnode!=null)
            {
                if (curnode.nodeValue == node.nodeValue)
                    return false;

                if(curnode.nodeValue > node.nodeValue)
                {
                    if (curnode.rightChildNode == null)
                    {
                        curnode.rightChildNode = node;
                        node.leftChildNode = null;
                        node.rightChildNode = null;
                        return true;
                    }
                    else
                        curnode = curnode.rightChildNode;                   
                }
                else
                {
                    if(curnode.leftChildNode == null)
                    {
                        if (curnode.leftChildNode == null)
                        {
                            curnode.leftChildNode = node;
                            node.leftChildNode = null;
                            node.rightChildNode = null;
                            return true;
                        }
                        else
                            curnode = curnode.leftChildNode;
                    }
                }
            }

            return false;

        }

        public bool DelNode(BinaryTreeNode node)
        {
            var curNode = _head;
            BinaryTreeNode parentNode = null;
            while(curNode!=null)
            {
                //三种情况（实际可简化两种）
                if(curNode.nodeValue == node.nodeValue)
                {
                    //要删除节点没有右节点，直接将被删除节点左节点替代删除节点
                    if(curNode.rightChildNode == null)
                    {
                        if(parentNode == null)
                        {
                            parentNode = _head;
                            
                            _head = parentNode.leftChildNode;
                            parentNode.leftChildNode = null;
                            parentNode.rightChildNode = null;

                            return true;
                        }
                        else
                        {
                            if(parentNode.leftChildNode == curNode)
                            {
                                parentNode.leftChildNode = curNode.leftChildNode;
                            }
                            else
                            {
                                parentNode.rightChildNode = curNode.leftChildNode;
                            }
                        }
                        
                    }
                    else //有右节点，可分为右节点有左节点和没有左节点两种情况，实际可以简化成一种，去被删除节点最左节点替代，最左节点的右子节点作为最左节点的父节点的左子节点
                    {
                        BinaryTreeNode replacenode = curNode.rightChildNode;
                        while(replacenode.leftChildNode!=null)
                        {
                            parentNode = replacenode;
                            replacenode = replacenode.leftChildNode;
                        }

                        curNode.nodeValue = replacenode.nodeValue;
                        if(parentNode !=null)
                            parentNode.leftChildNode = curNode.rightChildNode;
                        else
                        {
                            _head = curNode.rightChildNode;
                        }
                    }

                }

                if(curNode.nodeValue > node.nodeValue)
                {
                    parentNode = curNode;
                    curNode = curNode.rightChildNode;
                }

                if(curNode.nodeValue < node.nodeValue)
                {
                    parentNode = curNode;
                    curNode = curNode.leftChildNode;
                }

            }

            return false;

        }

        public BinaryTreeNode Find(int val)
        {
            BinaryTreeNode node = _head;
            while(node!=null)
            {
                if (val == node.nodeValue)
                    return node;
                if (val > node.nodeValue)
                    node = node.rightChildNode;
                else
                    node = node.leftChildNode;
            }
            return null;
        }

        public override void ConstructHuffmanTree(int[] vals)
        {
            throw new NotImplementedException();
        }
    }
}
