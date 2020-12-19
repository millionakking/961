using _961数据结构.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Queue
{
    public class PriorityQueue961<T> where T : IComparable
    {
        Heap<T> heap = new Heap<T>();
        public int Size { get { return heap.Count(); } }
        public bool isEmpty { get { return heap.Count() == 0; } }
        public T getFont()
        {
            return heap.top();
        }

        public void enqueue(T val)
        {
            heap.insert(val);
        }

        public T dequeue()
        {
            return heap.pop();
        }
    }
}
