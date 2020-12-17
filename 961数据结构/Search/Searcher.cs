using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构.Search
{
    public class Searcher
    {
        public static int sequenceSearch(int [] array, int val)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (val == array[i])
                    return i;
            }

            return -1;
        }

        public static int binarySearch(int[] array, int val)
        {
            Sort.InsertionSort(array);

            int head = array.Length - 1;
            int tail = 0;
            int mid = (head + tail) / 2;
            while(tail <= head)
            {
                if (array[mid] == val)
                    return mid;

                if(array[mid] < val)
                {
                    tail = mid + 1;
                    mid = (tail + head) / 2;
                }
                else
                {
                    head = mid - 1;
                    mid = (head + tail) / 2;
                }
            }

            return -1;
        }

    }
}
