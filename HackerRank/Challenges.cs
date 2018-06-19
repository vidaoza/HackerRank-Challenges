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

        internal static int FindNumberOfPermutations(int noOfStairs)
        {
            int noOfPermutations = 0;

            List<int> combinations = new List<int>();
            List<int> options = new List<int>() { 3, 2, 1 };
            List<int> availableOptions = options;
            var availableChairs = noOfStairs;
            var choice = 0;
            //List<int> availableOptions = options.Where(c => c != choice).ToList();
            List<int> combination = new List<int>();

            int counter = 0;
            while (counter < options.Count && availableChairs > 0)
            {
                while (availableChairs >= choice)
                {
                    availableChairs -= choice;
                    combination.Add(choice);
                }
                choice = options[++counter];


            }

            return noOfPermutations;
        }

        internal static bool DetectLinkedListCycle(LinkedList<int> list)
        {
            if (list.Count() == 1)
                return false;


            return list.Count == 1;
        }

        internal static int FindSmallest(int[] A)
        {
            List<int> arrrayList = A.ToList();

            var positiveNumbers = arrrayList.Where(s => s > 0).Distinct().ToList();
            if (positiveNumbers.Count > 0)
            {
                var counter = 0;
                var result = 1;
                positiveNumbers.Sort();

                while (counter < positiveNumbers.Count())
                {
                    if (result < positiveNumbers[counter])
                    {
                        return result;
                    }
                    else
                    {
                        if (result == positiveNumbers[counter])
                            result++;
                        else
                            result = positiveNumbers[counter];
                        //result = result == ?  result+ 1 : positiveNumbers[counter];
                        counter++;
                    }

                }
                return result;
            }
            else
                return 1;

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

        internal static int FindNumberIndexInNumberString(int A, int B)
        {
            string stringA = A.ToString();
            string stringB = B.ToString();

            if (stringB.Length < stringA.Length)
                return -1;

            var stringALength = stringA.Length;
            var counter = 0;

            while (counter < stringB.Length)
            {
                var remainingLength = stringB.Length - counter;
                if (remainingLength < stringALength)
                    return -1;

                var substring = stringB.Substring(counter, stringALength);
                if (stringA.CompareTo(substring) == 0)
                    return counter;

                counter++;
            }

            return -1;
        }

        internal static int FindLongestQuasiConstant(int[] A)
        {
            List<int> quasiConstantLengths = new List<int>();

            Array.Sort(A);
            var longest = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int selection = A[i];
                int counter = i + 1;
                List<int> sequense = new List<int>() { selection };
                while (counter < A.Length && A[counter] - A[i] < 2)
                {
                    sequense.Add(A[counter]);
                    counter++;
                }

                // Initial solution
                //while (counter < A.Length)
                //{
                //    if (A[counter] == selection || A[counter] == selection + 1 || A[counter] == selection - 1)
                //    {
                //        sequense.Add(A[counter]);
                //    }
                //    counter++;
                //}
                quasiConstantLengths.Add(sequense.Count());
                longest = Math.Max(longest, counter);
            }
            return quasiConstantLengths.Max();
        }

        internal static int FindBug(int[] A)
        {
            int n = A.Length;
            int result = 0;
            //if neighbour to the right is equal, add to adjacency count
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] == A[i + 1])
                    result = result + 1;
            }
            int r = -1;
            //compare each element to either side.
            // if elements are equal increase count
            // else decrease count
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                if (i != 0) //changed for readability, exclude first element
                {
                    //if current element is not equal to previous element add to count
                    //else subtract from it
                    if (A[i - 1] != A[i])
                        count = count + 1;
                    else
                        count = count - 1;
                }
                if (i < n - 1)  //exclude last element
                {
                    // if current is not equal to next element add to count
                    // else subtract from it
                    if (A[i] != A[i + 1]) //changed for readability
                        count = count + 1;
                    else
                        count = count - 1;
                }
                //select the largest value between count and r
                r = Math.Max(r, count);
            }
            return result + r;

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

        internal static void QueryMyQueue()
        {
            MyQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(35);
            myQueue.Enqueue(15);
            Console.WriteLine(myQueue.Peek());
            myQueue.Dequeue();
            Console.WriteLine(myQueue.Peek());
        }

        internal static int NoOfInversions = 0;

        internal static bool ExploreQueuesAndStacks(string brackets)
        {
            // { [ ( ] ) }

            // if string has uneven number of chars it is definitely unbalanced
            if (brackets.Length % 2 != 0)
                return false;

            Stack<char> bracketStack = new Stack<char>();
            for (int i = 0; i < brackets.Length; i++)
            {
                switch (brackets[i])
                {
                    case '(':
                        bracketStack.Push(')');
                        break;
                    case '{':
                        bracketStack.Push('}');
                        break;
                    case '[':
                        bracketStack.Push(']');
                        break;
                    default:
                        if (bracketStack.Count == 0 || bracketStack.Pop() != brackets[i])
                            return false;
                        break;
                }
            }
            return bracketStack.Count == 0;

            /*
            #region Stacks
            Stack<string> lifo = new Stack<string>();
            lifo.Push("Hello");
            lifo.Push("World");
            lifo.Push("!!");

            Console.WriteLine("Stacks");
            Console.WriteLine($"Peeking = {lifo.Peek()}");
            foreach (var item in lifo)
                Console.Write($"{item} ");

            Console.WriteLine();
            lifo.Pop();
            foreach (var item in lifo)
                Console.Write($"{item} ");

            Console.WriteLine($"\nPeeking = {lifo.Peek()}");
            #endregion

            #region Queue
            Queue<string> fifo = new Queue<string>();
            fifo.Enqueue("Hello");
            fifo.Enqueue("World");
            fifo.Enqueue("!!");

            Console.WriteLine("\nQueues");
            Console.WriteLine($"Peeking = {fifo.Peek()}");
            foreach (var item in fifo)
                Console.Write($"{item} ");

            Console.WriteLine();
            fifo.Dequeue();
            foreach (var item in fifo)
                Console.Write($"{item} ");

            Console.WriteLine($"\nPeeking = {fifo.Peek()}");
            #endregion

    */
        }
    }
}
