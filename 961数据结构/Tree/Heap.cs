using _961数据结构.Stack;
using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Tree
{

    public enum HeapType
    {
        big,small
    }

    public class Heap<T> where T : IComparable
    {
        protected const int DEFAULTSIZE = 100;
        protected int curPoolSize;

        protected HeapType _heaptype;

        protected T[] _heap;
        protected int _heapsize;

        public Heap(HeapType heaptype = HeapType.big)
        {
            curPoolSize = DEFAULTSIZE;
            _heap = new T[curPoolSize];
            _heapsize = 0;
            _heaptype = heaptype;
        }

        protected void relocalheap()
        {
            curPoolSize *= 2;
            T[] newheap = new T[curPoolSize];
            _heap.CopyTo(newheap, 0);
            _heap = newheap;
        }

        public void Heapify(T [] array)
        {
            if (array.Length > _heap.Length)
            {
                curPoolSize = array.Length + DEFAULTSIZE;
                _heap = new T[curPoolSize];
            }

            array.CopyTo(_heap,0);

            _heapsize = array.Length;
            for(int i = (_heapsize - 1) /2 ; i>= 0;i--)
            {
                siftDown(i);
            }
        }

        public void insert(T t)
        {
            if(_heapsize >= curPoolSize - 1)
            {
                relocalheap();
            }

            _heap[_heapsize] = t;
            _heapsize++;
            siftUp(_heapsize - 1);
        }

        protected void swithvalue(int i, int j)
        {
            T tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }

        protected void siftUp(int k)
        {
            if (k >= _heapsize)
                return;

            while(k >=0 && (_heaptype == HeapType.big ? _heap[k].CompareTo(_heap[parentidx(k)]) > 0 : _heap[k].CompareTo(_heap[parentidx(k)]) < 0))
            {
                swithvalue(k, k / 2);
                k = parentidx(k);
            }
        }

        protected int leftchildidx(int k)
        {
            return k * 2 + 1;
        }

        protected int rightchildidx(int k)
        {
            return (k+1)*2;
        }

        protected int parentidx(int k)
        {
            return (k  - 1) / 2 ;
        }

        protected void siftDown(int k)
        {
            while (leftchildidx(k) < _heapsize)
            {
                int extre = leftchildidx(k);
                if (rightchildidx(k) < _heapsize)
                {
                    int rightidx = rightchildidx(k);
                    if (_heaptype == HeapType.big && _heap[rightidx].CompareTo(_heap[extre]) > 0)
                        extre = rightidx;

                    if (_heaptype == HeapType.small && _heap[rightidx].CompareTo(_heap[extre]) < 0)
                        extre = rightidx;
                }

                if (_heaptype == HeapType.big && _heap[k].CompareTo(_heap[extre]) < 0 || _heaptype == HeapType.small && _heap[k].CompareTo(_heap[extre]) > 0)
                    swithvalue(k, extre);

                k = extre;
            }
        }

        public T top()
        {
            if (_heapsize <= 0)
                return default(T);

            return _heap[0];
        }

        public T pop()
        {
            if (_heapsize <= 0)
                return default(T);

            T extre = _heap[0];

            _heap[0] = _heap[_heapsize - 1];
            _heapsize--;
            siftDown(0);
            return extre;
        }

        public T replace(T t)
        {
            if (_heapsize <= 0)
                return default(T);

            T extre = _heap[0];
            _heap[0] = t;
            siftDown(0);
            return extre;
        }

        public int Count()
        {
            return _heapsize;
        }

        public T [] getSequence()
        {
            T[] result = new T[_heapsize];
            
            for(int i =0;i < _heapsize;i++)
            {
                result[i] = _heap[i];
            }

            return result;
        }

        public T [] getDLRSequenct()
        {

            if (_heapsize == 0)
                return null;

            Stack961<int> stack = new Stack961<int>();

            
            int curidx = 0;

            List<T> result = new List<T>();

            while(!stack.isEmpty() || curidx < _heapsize)
            {
                while(curidx < _heapsize)
                {
                    stack.push(curidx);
                    result.Add(_heap[curidx]);
                    curidx = leftchildidx(curidx);
                }

                curidx = stack.pop();
                curidx = rightchildidx(curidx);
               
            }

            return result.ToArray();
        }

        public T[] getLDRSequenct()
        {

            if (_heapsize == 0)
                return null;

            Stack961<int> stack = new Stack961<int>();

            int curidx = 0;

            List<T> result = new List<T>();

            while (!stack.isEmpty() || curidx < _heapsize)
            {
                while (curidx < _heapsize)
                {
                    stack.push(curidx);
                    curidx = leftchildidx(curidx);
                }

                curidx = stack.pop();
                result.Add(_heap[curidx]);
                curidx = rightchildidx(curidx);

            }

            return result.ToArray();
        }


    }
}
