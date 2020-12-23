using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Queue
{
    public class Queue961<T>
    {

        int defaultSize = 100;
        int TotalQueueNum;
        int _head;
        int _tail;

        T[] vals;

        public Queue961()
        {
            TotalQueueNum = defaultSize;
            vals = new T[TotalQueueNum];
            _head = 0;
            _tail = 0;
        }

        public bool isEmpty()
        {
            return _head == _tail;
        }

        public void clear()
        {
            _tail = _head;
        }

        public int Count()
        {
            return (_tail - _head + TotalQueueNum) % TotalQueueNum;
        }

        public bool isFull()
        {
            return _head % TotalQueueNum == (_tail + 1) % TotalQueueNum;
        }

        public bool enqueue(T val)
        {
            if (isFull())
                return false;

            vals[_tail] = val;
            _tail = (_tail + 1) % TotalQueueNum;

            return true;
        }

        public T top()
        {
            if (isEmpty())
                return default(T);

            return vals[_head];
        }
        public T dequeue()
        {
            if (isEmpty())
                return default(T);

            T val = vals[_head++];
            return val;
        }
    }
}
