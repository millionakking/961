using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构
{
    public class Sort<T> where T : IComparable
    {

        public static bool selectSort(T[] vals)
        {
            if (vals == null || vals.Length == 0)
                return false;

            for (int i = 0; i < vals.Length; i++)
            {
                int minidx = i;
                for (int j = i + 1; j < vals.Length; j++)
                {
                    if (vals[j].CompareTo(vals[minidx]) < 0)
                        minidx = j;
                }

                swap(vals, i, minidx);
            }

            return true;
        }

        public static bool MergeSort(T[] vals)
        {
            if (vals == null || vals.Length == 0)
                return false;

            doMergeSort(vals, 0, vals.Length - 1);

            return true;
        }

        protected static bool doMergeSort(T[] vals, int star, int end)
        {
            if (star >= end)
                return true;

            int mid = (star + end) / 2;
            doMergeSort(vals, star, mid);
            doMergeSort(vals, mid + 1, end);
            doMerge(vals, star, mid, end);

            return true;
        }

        protected static void doMerge(T[] vals, int low, int mid, int high)
        {
            T[] tmparry = new T[high - low + 1] ;
            int tmptp = 0;
            int leftp = low;
            int rightp = mid + 1;
            while(leftp <= mid && rightp <= high)
            {
                if(vals[leftp].CompareTo(vals[rightp]) < 0)
                {
                    tmparry[tmptp++] = vals[leftp++];
                }
                else
                {
                    tmparry[tmptp++] = vals[rightp++];
                }
            }

            for(;leftp<=mid;leftp++)
            {
                tmparry[tmptp++] = vals[leftp];
            }

            for (; rightp <= high; rightp++)
            {
                tmparry[tmptp++] = vals[rightp];
            }

            for(int i = low;i<=high;i++)
            {
                vals[i] = tmparry[i - low];
            }
        }

        public static bool bubbleSort(T[] vals)
        {
            if (vals == null || vals.Length == 0)
                return false;

            for (int i = 1; i < vals.Length - 1; i++)
            {
                for (int j = 0; j < vals.Length - i; j++)
                {
                    if (vals[j].CompareTo(vals[j + 1]) > 0)
                        swap(vals, j, j + 1);
                }
            }

            return true;
        }

        public static bool quickSort(T[] vals)
        {
            if (vals == null || vals.Length == 0)
                return false;

            qShort(vals, 0, vals.Length - 1);
            return true;
        }

        protected static bool qShort(T[] vals, int startidx, int enidx)
        {
            if (enidx <= startidx)
                return false;

            int low = startidx;
            int high = enidx;

            T standval = vals[low];
            while (low < high)
            {
                while (low < high && standval.CompareTo(vals[high]) <= 0)
                    high--;
                vals[low] = vals[high];
                while (low < high && standval.CompareTo(vals[low]) > 0)
                    low++;
                vals[high] = vals[low];
            }

            vals[low] = standval;
            qShort(vals, startidx, low - 1);
            qShort(vals, low + 1, enidx);

            return true;

        }

        public static bool ShellInsertionSort(T[] vals)
        {
            if (vals == null || vals.Length == 0)
                return false;

            for (int step = vals.Length / 2; step > 0; step = step / 2)
            {
                for (int i = step; i < vals.Length; i++)
                {
                    for (int j = i - step; j >= 0; j -= step)
                    {
                        if (vals[j].CompareTo(vals[j + step]) > 0)
                        {
                            swap(vals, j, j + step);
                        }
                        else
                            break;
                    }
                }
            }

            return true;
        }

        protected static void swap(T[] vals, int idx1, int idx2)
        {
            T temp = vals[idx1];
            vals[idx1] = vals[idx2];
            vals[idx2] = temp;
        }

        protected static void swap(List<T> vals, int idx1, int idx2)
        {
            T temp = vals[idx1];
            vals[idx1] = vals[idx2];
            vals[idx2] = temp;
        }

        public static bool InsertionSort(T[] vals)
        {
            for (int i = 1; i < vals.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (vals[j + 1].CompareTo(vals[j]) < 0)
                    {
                        swap(vals, j, j + 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return true;
        }

        public static bool InsertionSort(List<T> vals)
        {
            for (int i = 1; i < vals.Count; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (vals[j + 1].CompareTo(vals[j]) < 0)
                    {
                        swap(vals, j, j + 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return true;
        }

    }
}
