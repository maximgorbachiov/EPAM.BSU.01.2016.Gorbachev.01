using System;
using System.Collections.Generic;

namespace Sorter
{
    public class BubbleSortInterfaceOnDelegate
    {
        public delegate int Comparator1(int[] arr1, int[] arr2);

        static public void Sort(int[][] sourceArray, Comparator1 comparator)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            for (int i = 0; i < sourceArray.Length - 1; i++)
            {
                for (int j = 0; j < sourceArray.Length - 1; j++)
                {
                    if (sourceArray[j] != null)
                    {
                        if ((sourceArray[j + 1] != null) && (sourceArray[j + 1].Length > 0))
                        {
                            if (sourceArray[j].Length > 0)
                            {
                                if (comparator(sourceArray[j], sourceArray[j + 1]) > 0)
                                {
                                    Swap(ref sourceArray[j], ref sourceArray[j + 1]);
                                }
                            }
                        }
                        else
                        {
                            Swap(ref sourceArray[j], ref sourceArray[j + 1]);
                        }
                    }
                }
            }
        }

        static public void Sort(int[][] sourceArray, IComparer<int[]> comparator)
        {
            Sort(sourceArray, comparator.Compare);
        }

        static private void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array2;
            array2 = array1;
            array1 = temp;
        }
    }
}
