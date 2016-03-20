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
        class AscendingComparator : IComparator
        {
            public bool Compare(int a, int b)
            {
                return a > b;
            }
        }

        class SumSortedSign: ISortedSign
        {
            public int GetSortedSign(int[] array)
            {
                return array.Sum();
            }
        }

        class DiscendingComparator : IComparator
        {
            public bool Compare(int a, int b)
            {
                return a < b;
            }
        }

        class MaxElementSortedSign : ISortedSign
        {
            public int GetSortedSign(int[] array)
            {
                return array.Max();
            }
        }

        [TestCase]
        public void TestSortOfJaggedArrayByAscendingOfSumElements()
        {
            int[][] expectedArray = {new[] {2, 4, 6}, new[] {3, 5, 7}, new[] {4, 6, 8}};
            int[][] sortedArray = {new[] {4, 6, 8}, new[] {3, 5, 7}, new[] {2, 4, 6}};
            
            IComparator comparator = new AscendingComparator();
            ISortedSign sumSortedSign = new SumSortedSign();

            BubbleSort.Sort(sortedArray, comparator, sumSortedSign);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void TestSortOfJaggedArrayByDiscendingOfMaxElements()
        {
            int[][] expectedArray = { new[] { 4, 6, 8 }, new[] { 3, 5, 7 }, new[] { 2, 4, 6 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new[] { 3, 5, 7 }, new[] { 4, 6, 8 } };

            IComparator comparator = new DiscendingComparator();
            ISortedSign maxElementSortedSign = new MaxElementSortedSign();

            BubbleSort.Sort(sortedArray, comparator, maxElementSortedSign);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void TestSortOfJaggedArrayWithNullElementsByAscendingOfMaxElements()
        {
            int[][] expectedArray = { null, new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new[] { 4, 6, 8 } };

            IComparator comparator = new AscendingComparator();
            ISortedSign maxElementSortedSign = new MaxElementSortedSign();

            BubbleSort.Sort(sortedArray, comparator, maxElementSortedSign);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void TestSortOfJaggedArrayWithEmptyArraysByAscendingMaxElements()
        {
            int[][] expectedArray = { new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new int[0], new[] { 4, 6, 8 } };

            IComparator comparator = new AscendingComparator();
            ISortedSign maxElementSortedSign = new MaxElementSortedSign();

            BubbleSort.Sort(sortedArray, comparator, maxElementSortedSign);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void TestSortOfJaggedArrayWithEmptyAndNullsArraysByAscendingMaxElements()
        {
            int[][] expectedArray = { null, null, new int[0], new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new int[0], new int[0], new[] { 4, 6, 8 }, null };

            IComparator comparator = new AscendingComparator();
            ISortedSign maxElementSortedSign = new MaxElementSortedSign();

            BubbleSort.Sort(sortedArray, comparator, maxElementSortedSign);

            Assert.AreEqual(expectedArray, sortedArray);
        }
    }
}
