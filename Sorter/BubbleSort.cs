using System;

namespace Sorter
{
    public interface IComparator
    {
        bool Compare(int a, int b);
    }

    public interface ISortedSign
    {
        int GetSortedSign(int[] array);
    }

    static public class BubbleSort
    {
        static public void Sort(int[][] sourceArray, IComparator comparator, ISortedSign sortedSign)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            if (sortedSign == null)
            {
                throw new ArgumentNullException(nameof(sortedSign));
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
                                if (comparator.Compare(sortedSign.GetSortedSign(sourceArray[j]),
                                    sortedSign.GetSortedSign(sourceArray[j + 1])))
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

        static private void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array2;
            array2 = array1;
            array1 = temp;
        }
    }
}
