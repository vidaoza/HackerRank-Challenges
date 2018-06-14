using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    static class Challenges
    {
        internal static int[] ArraysLeftRotation(
            int[] array,
            int noOfRotations)
        {
            if (noOfRotations > array.Length)
                throw new Exception("No of rotations are more than no of elements in the array.");

            Stack<int> results = new Stack<int>();

            int count = 0;
            int arrayPosition = noOfRotations - 1;
            while (count < array.Length && arrayPosition >= 0)
            {
                results.Push(array[arrayPosition]);
                arrayPosition--;
                count++;
            }

            arrayPosition = noOfRotations;
            count = array.Length - 1;
            while (count >= noOfRotations)
            {
                results.Push(array[count]);
                count--;
            }

            return results.ToArray();

        }

        internal static void BubbleSort(
            int[] unsorted)
        {
            var swapCount = 0;
            var sorted = new int[unsorted.Length];

            for (int i = 0; i < unsorted.Length; i++)
            {
                for (int j = 0; j < unsorted.Length - 1; j++)
                {
                    if (unsorted[j] > unsorted[j + 1])
                    {
                        var tmp = unsorted[j + 1];
                        unsorted[j + 1] = unsorted[j];
                        unsorted[j] = tmp;
                        swapCount++;
                    }
                }
            }

            Console.WriteLine($"Array is sorted in {swapCount} swaps.");
            Console.WriteLine($"First Element: {unsorted[0]}");
            Console.WriteLine($"Last Element: {unsorted[unsorted.Length - 1]}");
        }

        internal static int MakeAnagrams(
            string firstString,
            string secondString)
        {
            var secondStringLookup = secondString.ToLookup(i => i);

            var list = from firstStringGroup in firstString.GroupBy(s => s)
                       let secondStringGroup = secondStringLookup[firstStringGroup.Key]
                       from i in (firstStringGroup.Count() < secondStringGroup.Count() ? firstStringGroup : secondStringGroup)
                       select i;

            return (firstString.Length - list.Count()) + (secondString.Length - list.Count());
        }

        internal static bool SearchStrings(
            string magazine,
            string note)
        {
            var noteArray = note.Split(' ');
            var dictionary = magazine.Split(' ').GroupBy(s => s)
                .ToDictionary(g => g.Key, g => g.Count());
            var canMakeMessage = true;
            var count = 0;
            while (canMakeMessage && count < noteArray.Length)
            {
                canMakeMessage = dictionary.ContainsKey(noteArray[count]);

                if (canMakeMessage && --dictionary[noteArray[count]] == 0)
                    dictionary.Remove(noteArray[count]);

                count++;
            }
            return canMakeMessage;
        }

        internal static void ComparisonSorting()
        {
            List<Player> players = new List<Player>()
            {
                new Player(){Score = 20, Name= "Smith"},
                new Player(){Score = 15, Name = "Jones"},
                new Player(){Score = 20, Name = "Jones"}
            };


            players.Sort(new PlayerComparer());

            foreach (var player in players)
            {
                Console.WriteLine($"Name: {player.Name} -\t {player.Score}");
            }
        }

        internal static void MergeSort(int[] array, int[] temp, int left, int right, ref int inversions)
        {
            var midpoint = 0;
            if (left < right)
            {
                midpoint = (left + right) / 2;
                MergeSort(array, temp, left, midpoint, ref inversions);
                MergeSort(array, temp, midpoint + 1, right, ref inversions);

                inversions = +MergeArrays(array, temp, left, right);
            }
        }

        internal static int FibonacciSeries(int n)
        {
            ////Iterative solution
            //int counter = 0;
            //List<int> series = new List<int>();
            //while (counter <= n)
            //{
            //    if (counter == 0 || counter == 1)
            //        series.Add(counter);
            //    else
            //        series.Add(series[counter - 1] + series[counter - 2]);
            //    counter++;
            //}
            //return series[n];

            if (n == 0 || n == 1)
                return n;
            else
                return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
        }

        internal static int LonelyInteger(int[] originalArray)
        {
            var lookup = originalArray.GroupBy(s => s)
                .ToLookup(g => g.Count(), g => g.Key);

            return lookup[1].Select(s => s).First();
        }

        internal static List<int> MergeSort(int[] array)
        {
            List<int> unsorted = array.ToList();
            int inversions = 0;

            if (unsorted.Count <= 1)
                return unsorted;

            int midPoint = unsorted.Count / 2;
            int[] lArray = new int[midPoint];
            int[] rArray = new int[(unsorted.Count - midPoint)];

            unsorted.CopyTo(0, lArray, 0, midPoint);
            unsorted.CopyTo(midPoint, rArray, 0, (unsorted.Count - midPoint));

            List<int> left = MergeSort(lArray);
            List<int> right = MergeSort(rArray);

            return Merge(left, right, ref inversions);
        }

        private static int MergeArrays(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            int inversions = 0;
            int leftEnd = (leftStart + rightEnd) / 2;
            int rightStart = leftEnd + 1;
            int arraySize = rightEnd - leftStart + 1;

            int leftCounter = leftStart;
            int rightCounter = rightStart;
            int counter = leftStart;

            while (leftCounter <= leftEnd && rightCounter <= rightEnd)
            {
                if (array[leftCounter] <= array[rightCounter])
                    temp[counter++] = array[leftCounter++];
                else
                {
                    temp[counter++] = array[rightCounter++];
                    inversions++;
                    NoOfInversions++;
                }
            }

            while (leftCounter < rightStart)
                temp[counter++] = array[leftCounter++];

            while (rightCounter <= rightEnd)
                temp[counter++] = array[rightCounter++];

            while (rightEnd >= 0)
            {
                array[rightEnd] = temp[rightEnd];
                rightEnd--;
            }

            return inversions;
        }

        private static List<int> Merge(List<int> left, List<int> right, ref int inversions)
        {
            List<int> merged = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        merged.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        merged.Add(right.First());
                        right.Remove(right.First());
                        NoOfInversions++;
                    }
                }
                else if (left.Count > 0)
                {
                    merged.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    merged.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return merged;
        }

        internal static int NoOfInversions = 0;
    }
}
