using System;
using System.Collections.Generic;
using System.Text;

namespace _961数据结构
{
    public class Sort
    {
        public static bool InsertionSort(IComparable[] vals)
        {
            IComparable tmp;
            for(int i = 1;i < vals.Length;i++)
            {
                tmp = vals[i];
                for(int j = i - 1;j>=0;j--)
                {
                    if(tmp.CompareTo(vals[j]) < 0)
                    {
                        vals[j + 1] = vals[j];
                        vals[j + 1] = tmp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return true;
        }

        public static bool InsertionSort(List<IComparable> vals)
        {
            IComparable tmp;
            for (int i = 1; i < vals.Count; i++)
            {
                tmp = vals[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (tmp.CompareTo(vals[j]) < 0)
                    {
                        vals[j + 1] = vals[j];
                        vals[j] = tmp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return true;
        }

        public static bool InsertionSort(int [] vals)
        {
            int tmp;
            for (int i = 1; i < vals.Length; i++)
            {
                tmp = vals[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (tmp < vals[j])
                    {
                        vals[j + 1] = vals[j];
                        vals[j] = tmp;
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
