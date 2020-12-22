using _961数据结构.Graph;
using _961数据结构.Queue;
using _961数据结构.Stack;
using _961数据结构.Tree;
using System;
using System.Collections.Generic;

namespace _961数据结构
{
    class Program
    {

        static Random random = new Random();

        static void testsort()
        {
            int sortcount = 16;
            int[] sortarray = new int[sortcount];
            for (int i = 0; i < sortarray.Length; i++)
            {
                sortarray[i] = random.Next(20);
            }

            int[] oparray = new int[sortcount];
            sortarray.CopyTo(oparray, 0);

            Console.WriteLine("开始测试直接插入排序:");
            Console.WriteLine("待排序数列:");
            printintarray(oparray);
            Console.WriteLine("");
            Sort<int>.InsertionSort(oparray);
            Console.WriteLine("排序完毕数列:");
            printintarray(oparray);
            Console.WriteLine("");


            sortarray.CopyTo(oparray, 0);
            Console.WriteLine("开始测试希尔插入排序:");
            Console.WriteLine("待排序数列:");
            printintarray(oparray);
            Console.WriteLine("");
            Sort<int>.ShellInsertionSort(oparray);
            Console.WriteLine("排序完毕数列:");
            printintarray(oparray);
            Console.WriteLine("");


            sortarray.CopyTo(oparray, 0);
            Console.WriteLine("开始测试选择排序:");
            Console.WriteLine("待排序数列:");
            printintarray(oparray);
            Console.WriteLine("");
            Sort<int>.selectSort(oparray);
            Console.WriteLine("排序完毕数列:");
            printintarray(oparray);
            Console.WriteLine("");

            sortarray.CopyTo(oparray, 0);
            Console.WriteLine("开始测试冒泡排序:");
            Console.WriteLine("待排序数列:");
            printintarray(oparray);
            Console.WriteLine("");
            Sort<int>.bubbleSort(oparray);
            Console.WriteLine("排序完毕数列:");
            printintarray(oparray);
            Console.WriteLine("");

            sortarray.CopyTo(oparray, 0);
            Console.WriteLine("开始测试快速排序:");
            Console.WriteLine("待排序数列:");
            printintarray(oparray);
            Console.WriteLine("");
            Sort<int>.quickSort(oparray);
            Console.WriteLine("排序完毕数列:");
            printintarray(oparray);
            Console.WriteLine("");

            sortarray.CopyTo(oparray, 0);
            Console.WriteLine("开始测试归并排序:");
            Console.WriteLine("待排序数列:");
            printintarray(oparray);
            Console.WriteLine("");
            Sort<int>.MergeSort(oparray);
            Console.WriteLine("排序完毕数列:");
            printintarray(oparray);
            Console.WriteLine("");
        }
        static void testqueue()
        {
            int maxvals = 200;
            int[] vals = new int[maxvals];
            for (int i = 1; i < maxvals; i++)
            {
                vals[i] = i;
            }

            Queue961<int> queue = new Queue961<int>();

            //测试插入直至栈满
            Console.WriteLine("开始测试压队列:");
            for (int i = 1; i < maxvals; i++)
            {
                bool bsuccess = queue.enqueue(vals[i]);
                if (bsuccess)
                {
                    printQueueTop(queue);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("压栈失败: 当前压队列数{0}，是否队列满{1},当前队列内元素数{2}", i, queue.isFull(), queue.Count());
                    break;
                }
            }

            //测试弹出直至栈空
            Console.WriteLine("开始测试出队列:");
            for (int i = 1; i < maxvals / 4; i++)
            {
                printQueueTop(queue);
                int? val = queue.dequeue();


                if (val == null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("弹栈失败: 当前弹队列数{0}，是否队列空{1},当前队列内元素数{2}", i, queue.isEmpty(), queue.Count());
                    break;
                }
            }

            //测试插入直至栈满
            Console.WriteLine("开始测试压队列:");
            for (int i = 1; i < maxvals; i++)
            {
                bool bsuccess = queue.enqueue(vals[i]);
                if (bsuccess)
                {
                    printQueueTop(queue);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("压栈失败: 当前压队列数{0}，是否队列满{1},当前队列内元素数{2}", i, queue.isFull(), queue.Count());
                    break;
                }
            }
        }
        static void testStack961()
        {
            int maxvals = 200;
            int[] vals = new int[maxvals];
            for (int i = 1; i < maxvals; i++)
            {
                vals[i] = i;
            }

            Stack961<int> stack = new Stack961<int>();

            //测试插入直至栈满
            Console.WriteLine("开始测试压栈:");
            for (int i = 1; i < maxvals; i++)
            {
                bool bsuccess = stack.push(vals[i]);
                if (bsuccess)
                {
                    printStackTop(stack);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("压栈失败: 当前压栈数{0}，是否栈满{1},当前栈内元素数{2}", i, stack.isFull(), stack.Count());
                    break;
                }
            }

            //测试弹出直至栈空
            Console.WriteLine("开始测试弹栈:");
            for (int i = 1; i < maxvals; i++)
            {
                printStackTop(stack);
                int? val = stack.pop();


                if (val == null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("弹栈失败: 当前弹栈数{0}，是否栈空{1},当前栈内元素数{2}", i, stack.isEmpty(), stack.Count());
                    break;
                }
            }
        }

        static void printintarray(int[] array)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(String.Format("{0} ", array[i]));
            }
        }

        static void printStackTop(Stack961<int> stack)
        {
            Console.Write(String.Format("{0} ", stack.top()));
        }

        static void printQueueTop(Queue961<int> queue)
        {
            Console.Write(String.Format("{0} ", queue.top()));
        }

        static void testSearch()
        {
            int maxvals = 20000;
            int[] vals = new int[maxvals];
            for (int i = 1; i < maxvals; i++)
            {
                vals[i] = i;
            }


            Console.WriteLine("测试查找节点:");
            printintarray(vals);
            Console.WriteLine("");

            int findval = random.Next(maxvals);
            Console.WriteLine(String.Format("查找数字为:{0}", findval));


            int idx = Search.Searcher.sequenceSearch(vals, findval);
            Console.WriteLine(String.Format("顺序查找结果:{0}", idx));
            Console.WriteLine("");


            idx = Search.Searcher.binarySearch(vals, findval);
            Console.WriteLine(String.Format("二分查找结果:{0}", idx));
            Console.WriteLine("");
        }



        static void printBinaryNode(List<BinaryTreeNode> nodes)
        {
            foreach (var se in nodes)
            {
                Console.Write(String.Format("{0} ", se.nodeValue));
            }
        }

        static void printGraphNode(List<GraphNode> nodes)
        {
            foreach (var se in nodes)
            {
                Console.Write(String.Format("{0} ", se.Name));
            }
        }

        static void printMiniBuildTreeSequence(MinimumTreeNode[] nodes)
        {
            foreach (var se in nodes)
            {
                if(string.IsNullOrEmpty(se.ParentName))
                    Console.Write(String.Format("首节点 : {0} |", se.Name));
                else
                    Console.Write(String.Format(" {0}-{1} |", se.ParentName, se.Name));
            }
        }

        static void testAvlTree()
        {
            int treenodenum = 10;
            int[] vals = new int[treenodenum];
            for (int i = 0; i < treenodenum; i++)
            {
                vals[i] = i;
            }

            for (int i = 0; i < treenodenum; i++)
            {
                int idx1 = random.Next(treenodenum);
                int idx2 = random.Next(treenodenum);
                int tmp = vals[idx1];
                vals[idx1] = vals[idx2];
                vals[idx2] = tmp;
            }

            Console.WriteLine("构建树节点:");
            printintarray(vals);
            Console.WriteLine("");

            AVLTree avltree = new AVLTree();
            avltree.Construct(vals);

            Console.WriteLine("先序遍历结果:");
            Console.WriteLine("递归调用先序遍历结果:");
            var sequence = avltree.DLRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("中序遍历结果:");
            sequence = avltree.LDRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            for (int i = 0; i < treenodenum; i++)
            {
                var findval = random.Next(treenodenum);
                Console.WriteLine(String.Format("查找数字为:{0}", findval));
                var node = avltree.Find(findval);
                if (node == null)
                    Console.WriteLine(String.Format("未能查找到数字:{0}", findval));
                else
                {
                    Console.WriteLine(String.Format("成功查找到数字:{0}", node.nodeValue));
                }

                if (node != null)
                {
                    var bstval = node.nodeValue;
                    Console.WriteLine(String.Format("测试删除节点:{0}", bstval));
                    var bok = avltree.DelNode(node.nodeValue);
                    if (bok)
                    {
                        Console.WriteLine(String.Format("成功删除节点:{0}", bstval));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("删除节点:{0} 失败", bstval));
                    }

                    Console.WriteLine("先序遍历结果:");
                    Console.WriteLine("递归调用先序遍历结果:");
                    sequence = avltree.DLRSequence();
                    printBinaryNode(sequence);
                    Console.WriteLine("");

                    Console.WriteLine("中序遍历结果:");
                    sequence = avltree.LDRSequence();
                    printBinaryNode(sequence);
                    Console.WriteLine("");
                }
            }
        }

        static void testHeap()
        {
            int treenodenum = 10;
            int[] vals = new int[treenodenum];
            for (int i = 0; i < treenodenum; i++)
            {
                vals[i] = random.Next(treenodenum);
            }


            Console.WriteLine("构建堆节点:");
            printintarray(vals);
            Console.WriteLine("");

            Heap<int> bsttree = new Heap<int>();
            bsttree.Heapify(vals);

            Console.WriteLine("堆化结果:");
            var sequence = bsttree.getSequence();
            printintarray(sequence);
            Console.WriteLine("");

            Console.WriteLine("先序遍历结果:");
            Console.WriteLine("递归调用先序遍历结果:");
            sequence = bsttree.getDLRSequenct();
            printintarray(sequence);
            Console.WriteLine("");

            Console.WriteLine("中序遍历结果:");
            sequence = bsttree.getLDRSequenct();
            printintarray(sequence);
            Console.WriteLine("");


            List<int> sortlist = new List<int>();
            Console.WriteLine("堆化排序结果:");
            while (bsttree.Count() > 0)
            {
                Console.WriteLine("弹出最大值:");
                int extrenum = bsttree.pop();
                sortlist.Add(extrenum);
                Console.Write(String.Format("{0} ", extrenum));
                Console.WriteLine("");

                Console.WriteLine("排序序列:");
                printintarray(sortlist.ToArray());
                Console.WriteLine("");

                Console.WriteLine("堆化结果:");
                sequence = bsttree.getSequence();
                printintarray(sequence);
                Console.WriteLine("");

                Console.WriteLine("先序遍历结果:");
                Console.WriteLine("递归调用先序遍历结果:");
                sequence = bsttree.getDLRSequenct();
                printintarray(sequence);
                Console.WriteLine("");

                Console.WriteLine("中序遍历结果:");
                sequence = bsttree.getLDRSequenct();
                printintarray(sequence);
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static void testBSTTree()
        {
            int treenodenum = 20;
            int[] vals = new int[treenodenum];
            for (int i = 0; i < treenodenum; i++)
            {
                vals[i] = random.Next(treenodenum);
            }

            Console.WriteLine("构建树节点:");
            printintarray(vals);
            Console.WriteLine("");

            BSTTree bsttree = new BSTTree();
            bsttree.Construct(vals);

            Console.WriteLine("先序遍历结果:");
            Console.WriteLine("递归调用先序遍历结果:");
            var sequence = bsttree.DLRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("中序遍历结果:");
            sequence = bsttree.LDRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");


            for (int i = 0; i < treenodenum; i++)
            {
                var findval = random.Next(treenodenum);
                Console.WriteLine(String.Format("查找数字为:{0}", findval));
                var node = bsttree.Find(findval);
                if (node == null)
                    Console.WriteLine(String.Format("未能查找到数字:{0}", findval));
                else
                {
                    Console.WriteLine(String.Format("成功查找到数字:{0}", node.nodeValue));
                }

                if (node != null)
                {
                    var bstval = node.nodeValue;
                    Console.WriteLine(String.Format("测试删除节点:{0}", bstval));
                    var bok = bsttree.DelNode(node.nodeValue);
                    if (bok)
                    {
                        Console.WriteLine(String.Format("成功删除节点:{0}", bstval));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("删除节点:{0} 失败", bstval));
                    }

                    Console.WriteLine("先序遍历结果:");
                    Console.WriteLine("递归调用先序遍历结果:");
                    sequence = bsttree.DLRSequence();
                    printBinaryNode(sequence);
                    Console.WriteLine("");

                    Console.WriteLine("中序遍历结果:");
                    sequence = bsttree.LDRSequence();
                    printBinaryNode(sequence);
                    Console.WriteLine("");
                }
            }

        }

        static void testBinaryTree()
        {
            int treenodenum = 10;
            int[] vals = new int[treenodenum];
            for (int i = 0; i < treenodenum; i++)
            {
                vals[i] = i;
            }

            BinaryTree tree = new BinaryTree();
            tree.Construct(vals);

            Console.WriteLine("先序遍历结果:");
            Console.WriteLine("递归调用先序遍历结果:");
            var sequence = tree.DLRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("栈调用先序遍历结果:");
            sequence = tree.DLRStackSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("中序遍历结果:");
            sequence = tree.LDRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("栈调用中序遍历结果:");
            sequence = tree.LDRStackSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("后序序遍历结果:");
            sequence = tree.LRDSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("栈调用后序遍历结果:");
            sequence = tree.LRDStackSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("层序遍历结果:");
            sequence = tree.LevelOrder();
            printBinaryNode(sequence);
            Console.WriteLine("");

            vals = new int[treenodenum];
            for (int i = 0; i < treenodenum; i++)
            {
                vals[i] = random.Next(20);
            }


            Console.WriteLine("霍夫曼节点:");
            printintarray(vals);
            Console.WriteLine("");

            tree = new BinaryTree();
            tree.ConstructHuffmanTree(vals);
            Console.WriteLine("层序遍历结果:");
            sequence = tree.LevelOrder();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("先序遍历结果:");
            Console.WriteLine("递归调用先序遍历结果:");
            sequence = tree.DLRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("中序遍历结果:");
            sequence = tree.LDRSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("后序序遍历结果:");
            sequence = tree.LRDSequence();
            printBinaryNode(sequence);
            Console.WriteLine("");


        }

        static void testGraph()
        {
            List<GraphNode> nodes = new List<GraphNode>();
            var nodea = new GraphNode { Name = "A" };
            var nodeb = new GraphNode { Name = "B" };
            var nodec = new GraphNode { Name = "C" };
            var noded = new GraphNode { Name = "D" };
            var nodee = new GraphNode { Name = "E" };
            nodes.Add(nodea);
            nodes.Add(nodeb);
            nodes.Add(nodec);
            nodes.Add(noded);
            nodes.Add(nodee);

            List<GraphEdge> edges = new List<GraphEdge>();
            edges.Add(new GraphEdge { StartNode = nodea, EndNode = nodeb, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = nodea, EndNode = nodec, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = nodea, EndNode = nodee, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = nodeb, EndNode = noded, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = nodec, EndNode = nodeb, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = nodec, EndNode = noded, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = noded, EndNode = nodea, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = nodee, EndNode = nodec, Weights = 1 });
            edges.Add(new GraphEdge { StartNode = nodee, EndNode = noded, Weights = 1 });

            Graph961 graph = new GraphAdjacencyMatrix(nodes.ToArray(), edges.ToArray());


            Console.WriteLine("广度遍历结果:");
            var sequence = graph.BFS();
            printGraphNode(sequence);
            Console.WriteLine("");

            Console.WriteLine("深度遍历结果:");
            sequence = graph.DFS();
            printGraphNode(sequence);
            Console.WriteLine("");


            nodes = new List<GraphNode>();
            nodea = new GraphNode { Name = "A" };
            nodeb = new GraphNode { Name = "B" };
            nodec = new GraphNode { Name = "C" };
            noded = new GraphNode { Name = "D" };
            nodee = new GraphNode { Name = "E" };
            var nodef = new GraphNode { Name = "F" };
            var nodeg = new GraphNode { Name = "G" };

            nodes.Add(nodea);
            nodes.Add(nodeb);
            nodes.Add(nodec);
            nodes.Add(noded);
            nodes.Add(nodee);
            nodes.Add(nodef);
            nodes.Add(nodeg);

            edges = new List<GraphEdge>();
            edges.Add(new GraphEdge { StartNode = nodea, EndNode = nodeb, Weights = 7 });
            edges.Add(new GraphEdge { StartNode = nodea, EndNode = noded, Weights = 5 });

            edges.Add(new GraphEdge { StartNode = nodeb, EndNode = nodea, Weights = 7 });
            edges.Add(new GraphEdge { StartNode = nodeb, EndNode = nodec, Weights = 8 });
            edges.Add(new GraphEdge { StartNode = nodeb, EndNode = noded, Weights = 9 });
            edges.Add(new GraphEdge { StartNode = nodeb, EndNode = nodee, Weights = 7 });

            edges.Add(new GraphEdge { StartNode = nodec, EndNode = nodeb, Weights = 8 });
            edges.Add(new GraphEdge { StartNode = nodec, EndNode = nodee, Weights = 5 });

            edges.Add(new GraphEdge { StartNode = noded, EndNode = nodea, Weights = 5 });
            edges.Add(new GraphEdge { StartNode = noded, EndNode = nodeb, Weights = 9 });
            edges.Add(new GraphEdge { StartNode = noded, EndNode = nodee, Weights = 15 });
            edges.Add(new GraphEdge { StartNode = noded, EndNode = nodef, Weights = 6 });

            edges.Add(new GraphEdge { StartNode = nodee, EndNode = nodeb, Weights = 7 });
            edges.Add(new GraphEdge { StartNode = nodee, EndNode = nodec, Weights = 5 });
            edges.Add(new GraphEdge { StartNode = nodee, EndNode = noded, Weights = 15 });
            edges.Add(new GraphEdge { StartNode = nodee, EndNode = nodef, Weights = 8 });
            edges.Add(new GraphEdge { StartNode = nodee, EndNode = nodeg, Weights = 9 });

            edges.Add(new GraphEdge { StartNode = nodef, EndNode = noded, Weights = 6 });
            edges.Add(new GraphEdge { StartNode = nodef, EndNode = nodee, Weights = 8 });
            edges.Add(new GraphEdge { StartNode = nodef, EndNode = nodeg, Weights = 11 });

            edges.Add(new GraphEdge { StartNode = nodeg, EndNode = nodee, Weights = 9 });
            edges.Add(new GraphEdge { StartNode = nodeg, EndNode = nodef, Weights = 11 });


            graph = new GraphAdjacencyMatrix(nodes.ToArray(), edges.ToArray());


            
            var minitree = graph.miniGeneralTree_Prim(0);
            Console.WriteLine(String.Format("Prim 生成树: 代价{0}", minitree.TotalCost));
            Console.WriteLine("Prim 生成树: 生成路径:");
            var minibuildsequence = minitree.BuildSequence;
            printMiniBuildTreeSequence(minibuildsequence);
            Console.WriteLine("");

            minitree = graph.miniGeneralTree_Kruskal();
            Console.WriteLine(String.Format("Kruskal 生成树: 代价{0}", minitree.TotalCost));
            Console.WriteLine("Kruskal 生成树: 生成路径:");
            minibuildsequence = minitree.BuildSequence;
            printMiniBuildTreeSequence(minibuildsequence);
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            //testqueue();
            //testStack961();
            //testBinaryTree();
            //testsort();
            //testBSTTree();
            //testAvlTree();
            //testHeap();
            //testSearch();

            testGraph();
            Console.ReadKey();
        }
    }
}
