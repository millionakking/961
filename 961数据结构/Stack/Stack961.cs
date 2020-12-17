using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Stack
{
    public class Stack961<T>
    {
        int _defaultMaxNum = 100;
        int TotalStatckNum;
        int _head;
        int _tail;

        public Stack961()
        {
            _head = 0;
            _tail = 0;
            TotalStatckNum = _defaultMaxNum;
            vals = new T[TotalStatckNum];
        }

        public bool isEmpty()
        {
            return _head == _tail;
        }

        public int Count()
        {
            return (_tail - _head + TotalStatckNum) % TotalStatckNum;
        }

        public bool isFull()
        {
            return _head % TotalStatckNum == (_tail + 1) % TotalStatckNum;
        }

        public T pop()
        {
            if (isEmpty())
                return default(T);

            T val = vals[_tail - 1];
            _tail = (_tail - 1) % TotalStatckNum;

            return val;
        }

        public bool push(T val)
        {
            if (isFull())
                return false;

            vals[_tail] = val;
            _tail = (_tail + 1) % TotalStatckNum;

            return true;
        }

        public T top()
        {
            if (isEmpty())
                return default(T);

            return vals[_tail - 1]; ;
        }

        private T[] vals;
    }
}
