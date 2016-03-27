using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sorter.NUnit.Tests
{
    [TestFixture]
    public class SorterTests
    {
        class AscendingComparator : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                int sum1 = a.Sum();
                int sum2 = b.Sum();

                if (sum1 == sum2)
                {
                    return 0;
                }

                return (sum1 > sum2) ? 1 : -1;
            }
        }

        class DiscendingComparator : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                int sum1 = a.Sum();
                int sum2 = b.Sum();

                if (sum1 == sum2)
                {
                    return 0;
                }

                return (sum1 < sum2) ? 1 : -1;
            }
        }

        [TestCase]
        public void Test_SortOfJaggedArray_ByAscendingOfSumElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = {new[] {2, 4, 6}, new[] {3, 5, 7}, new[] {4, 6, 8}};
            int[][] sortedArray = {new[] {4, 6, 8}, new[] {3, 5, 7}, new[] {2, 4, 6}};
            
            IComparer<int[]> comparator = new AscendingComparator();

            BubbleSort.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_ByDiscendingOfMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { new[] { 4, 6, 8 }, new[] { 3, 5, 7 }, new[] { 2, 4, 6 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new[] { 3, 5, 7 }, new[] { 4, 6, 8 } };

            IComparer<int[]> comparator = new DiscendingComparator();

            BubbleSort.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithNullElements_ByAscendingOfMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { null, new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new[] { 4, 6, 8 } };

            IComparer<int[]> comparator = new AscendingComparator();

            BubbleSort.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithEmptyArrays_ByAscendingMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new int[0], new[] { 4, 6, 8 } };

            IComparer<int[]> comparator = new AscendingComparator();

            BubbleSort.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithEmptyAndNullsArrays_ByAscendingMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { null, null, new int[0], new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new int[0], new int[0], new[] { 4, 6, 8 }, null };

            IComparer<int[]> comparator = new AscendingComparator();

            BubbleSort.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_ByAscendingOfSumElements_DelegateOnInterface()
        {
            int[][] expectedArray = { new[] { 2, 4, 6 }, new[] { 3, 5, 7 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 4, 6, 8 }, new[] { 3, 5, 7 }, new[] { 2, 4, 6 } };

            BubbleSortInterfaceOnDelegate.Comparator1 comparator = new AscendingComparator().Compare;

            BubbleSortInterfaceOnDelegate.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_ByDiscendingOfMaxElements_DelegateOnInterface()
        {
            int[][] expectedArray = { new[] { 4, 6, 8 }, new[] { 3, 5, 7 }, new[] { 2, 4, 6 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new[] { 3, 5, 7 }, new[] { 4, 6, 8 } };

            BubbleSortInterfaceOnDelegate.Comparator1 comparator = new DiscendingComparator().Compare;

            BubbleSortInterfaceOnDelegate.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithNullElements_ByAscendingOfMaxElements_DelegateOnInterface()
        {
            int[][] expectedArray = { null, new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new[] { 4, 6, 8 } };

            BubbleSortInterfaceOnDelegate.Comparator1 comparator = new AscendingComparator().Compare;

            BubbleSortInterfaceOnDelegate.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithEmptyArrays_ByAscendingMaxElements_DelegateOnInterface()
        {
            int[][] expectedArray = { new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new int[0], new[] { 4, 6, 8 } };

            BubbleSortInterfaceOnDelegate.Comparator1 comparator = new AscendingComparator().Compare;

            BubbleSortInterfaceOnDelegate.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithEmptyAndNullsArrays_ByAscendingMaxElements_DelegateOnInterface()
        {
            int[][] expectedArray = { null, null, new int[0], new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new int[0], new int[0], new[] { 4, 6, 8 }, null };

            BubbleSortInterfaceOnDelegate.Comparator1 comparator = new AscendingComparator().Compare;

            BubbleSortInterfaceOnDelegate.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }
    }
}
