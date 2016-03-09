using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    static public class BubbleSort
    {
        private struct ArrayStruct
        {
            public int[] array;
            public int comparedElement;
        }

        private delegate bool Comparer(int element1, int element2);
        private delegate int GetComparedElement(int[] array);
        static private Comparer compareAscending = (x, y) => x > y;
        static private Comparer compareDiscending = (x, y) => x < y;
        static private GetComparedElement getMinElement = (int[] array) => GetElement(array, compareAscending);
        static private GetComparedElement getMaxElement = (int[] array) => GetElement(array, compareDiscending); 

        static public void SortByMaxSum(int[][] sourceArray, bool isSortAscending = true)
        {
            Sort(sourceArray, isSortAscending, GetSumOfArrayElements);
        }

        static public void SortByMaxElement(int[][] sourceArray, bool isSortAscending = true)
        {
            Sort(sourceArray, isSortAscending, getMaxElement);
        }

        static public void SortByMinElement(int[][] sourceArray, bool isSortAscending = true)
        {
            Sort(sourceArray, isSortAscending, getMinElement);
        }

        static private void Sort(int[][] sourceArray, bool isSortAscending, GetComparedElement getComparedElementFunc)
        {
            if (sourceArray != null)
            {
                if (isSortAscending)
                {
                    SortByComparer(sourceArray, getComparedElementFunc, compareAscending);
                }
                else
                {
                    SortByComparer(sourceArray, getComparedElementFunc, compareDiscending);
                }
            }
            else
            {
                throw new Exception("Source array is null");
            }
        }

        static private void SortByComparer(int[][] sourceArray, GetComparedElement getComparedElementFunc, Comparer comparator)
        {
            int firstNotNullArrayIndex = RaiseNullArrays(sourceArray);
            firstNotNullArrayIndex = RaiseZeroArrays(sourceArray, firstNotNullArrayIndex);
            ArrayStruct[] arrayStructes = GetArrayStructes(sourceArray, firstNotNullArrayIndex, getComparedElementFunc);

            for (int i = firstNotNullArrayIndex; i < arrayStructes.Length - 1; i++)
            {
                for (int j = i + 1; j < arrayStructes.Length; j++)
                {
                    if (comparator(arrayStructes[i].comparedElement, arrayStructes[j].comparedElement))
                    {
                        Swap(arrayStructes, i, j);
                    }
                }
            }
            for (int i = firstNotNullArrayIndex; i < sourceArray.Length; i++)
            {
                sourceArray[i] = arrayStructes[i].array;
            }
        }

        static private int RaiseNullArrays(int[][] sourceArray)
        {
            int firstNotNullArrayIndex = 0;

            for (int i = firstNotNullArrayIndex; i < sourceArray.Length; i++)
            {
                if (sourceArray[i] == null)
                {
                    SwapArrays(sourceArray, firstNotNullArrayIndex, i);
                    firstNotNullArrayIndex++;
                }
            }
            return firstNotNullArrayIndex;
        }

        static private int RaiseZeroArrays(int[][] sourceArray, int index)
        {
            for (int i = index; i < sourceArray.Length; i++)
            {
                if (sourceArray[i].Length == 0)
                {
                    SwapArrays(sourceArray, index, i);
                    index++;
                }
            }
            return index;
        }

        static private ArrayStruct[] GetArrayStructes(int[][] sourceArray, int firstNotNullArrayIndex, GetComparedElement getElemFunc)
        {
            ArrayStruct[] arrayStructes = new ArrayStruct[sourceArray.Length];

            for (int i = firstNotNullArrayIndex; i < arrayStructes.Length; i++)
            {
                ArrayStruct element = new ArrayStruct();
                element.array = sourceArray[i];
                element.comparedElement = getElemFunc(sourceArray[i]);
                arrayStructes[i] = element;
            }
            return arrayStructes;
        }

        static private int GetSumOfArrayElements(int[] array)
        {
            int resultSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                resultSum += array[i];
            }
            return resultSum;
        }

        static private int GetElement(int[] array, Comparer comparator)
        {
            int elem = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (comparator(elem, array[i]))
                {
                    elem = array[i];
                }
            }
            return elem;
        }

        static private void Swap(ArrayStruct[] array, int i, int j)
        {
            ArrayStruct temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static private void SwapArrays(int[][] array, int i, int j)
        {
            int[] temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
