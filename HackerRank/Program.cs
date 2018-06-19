using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            char function = 'R';// GetUserInput();

            while (function != 'X')
            {
                Console.WriteLine();
                switch (function)
                {
                    case 'A':
                        {
                            #region Make Anagrams
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Make Anagram");
                                string firstString = "glue";
                                string secondString = "llegs";
                                Console.WriteLine($"Original strings: \n1 : {firstString} \n2 : {secondString}");

                                int totalDeletions = Challenges.MakeAnagrams(firstString, secondString);
                                Console.WriteLine($"Number of deletions : {totalDeletions}");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'B':
                        {
                            #region Bubble Sort
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Bubble sort");
                                var originalArray = new int[] { 6, 10, 7, 6, 8, 9 };
                                Console.WriteLine("Original array");
                                for (int i = 0; i < originalArray.Length; i++)
                                    Console.Write($"{originalArray[i]} ");
                                Console.WriteLine();
                                Challenges.BubbleSort(originalArray);

                                //var smallestInt = Challenges.FindSmallest(originalArray);
                                //var smallestInt = Challenges.FindNumberIndexInNumberString(29, 521);
                                //var smallestInt = Challenges.FindLongestQuasiConstant(originalArray);
                                //var smallestInt = Challenges.FindBug(originalArray);
                                //Console.WriteLine(smallestInt);
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'C':
                        {
                            #region Comparer Implementation
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Comparer Implementation");
                                Challenges.ComparisonSorting();
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'D':
                        {
                            #region Detect Cycles in Linked List
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Detect Linked List Cycles");
                                LinkedList<int> list = new LinkedList<int>();
                                LinkedListNode<int> first = new LinkedListNode<int>(1);

                                list.AddFirst(first);
                                list.AddAfter(first, 2);
                                list.AddAfter(first, 3);

                                bool hasCycle = Challenges.DetectLinkedListCycle(list);
                                Console.WriteLine($"\n Has Cycle : {hasCycle}");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'F':
                        {
                            #region Fibonacci
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Fibonacci series");
                                int placeInSeries = 9;
                                Console.WriteLine($"Find value in the {placeInSeries}th place of the Fibonacci series.");

                                int value = Challenges.FibonacciSeries(placeInSeries);
                                Console.WriteLine($"Value in {placeInSeries}th place : {value}");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'H':
                        {
                            #region Hash Tables
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Comparer Implementation");
                                Challenges.ComparisonSorting();
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'I':
                        {
                            #region Lonely Integer
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Lonely Integer");
                                int[] originalArray = new[] { 0, 0, 1, 1, 2 };
                                int lonelyInteger = Challenges.LonelyInteger(originalArray);
                                Console.WriteLine("Original array");
                                for (int i = 0; i < originalArray.Length; i++)
                                    Console.Write($"{originalArray[i]} ");

                                Console.WriteLine($"\nSingle Integer: {lonelyInteger}");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'L':
                        {
                            #region Left shift
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Left shift : {3}");
                                int[] originalArray = new[] { 1, 2, 3, 4, 5 };
                                int[] shiftedArray = Challenges.ArraysLeftRotation(originalArray, 7);
                                Console.WriteLine("Original array");
                                for (int i = 0; i < originalArray.Length; i++)
                                    Console.Write($"{originalArray[i]} ");

                                Console.WriteLine("\nShifted array");
                                for (int i = 0; i < shiftedArray.Length; i++)
                                    Console.Write($"{shiftedArray[i]} ");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'M':
                        {
                            #region Merge sort
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Merge Sort");
                                Challenges.NoOfInversions = 0;
                                //int[] array = new int[] { 1,1,1,2,2 };
                                int[] array = new int[] { 2, 1, 3, 1, 2 };
                                //int[] array = new int[] { 9, 2, 6, 5, 3, 10, 1, 7 };
                                Console.WriteLine("\nUnsorted array");
                                for (int i = 0; i < array.Length; i++)
                                    Console.Write($"{array[i]} ");
                                int inversions = 0;
                                Challenges.MergeSort(array, new int[array.Length], 0, array.Length - 1, ref inversions);
                                Console.WriteLine($"\n{inversions}");
                                for (int i = 0; i < array.Length; i++)
                                    Console.Write($"{array[i]} ");

                                //List<int> sorted = Challenges.MergeSort(array);
                                //Console.WriteLine("\nSorted array");
                                //for (int i = 0; i < sorted.Count; i++)
                                //    Console.Write($"{sorted[i]} ");
                                Console.WriteLine($"\n{Challenges.NoOfInversions}");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'P':
                        {
                            #region Number of Permutations
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Find number of Permutations");
                                int noOfStairs = 5;
                                int noOfPermutations = Challenges.FindNumberOfPermutations(noOfStairs);
                                Console.WriteLine($"Number of Permutations: {noOfPermutations}");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'R':
                        {
                            #region Queue by stack
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine("Implement a queue by using two stacks.");
                                Challenges.QueryMyQueue();
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'S':
                        {
                            #region Search and Match Strings
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine("Search and Match Strings");
                                string magazine = "grand give me one grand today me night";
                                string note = "one give one grand today one";

                                bool canMakeNote = Challenges.SearchStrings(magazine, note);
                                Console.WriteLine(canMakeNote ? "Yes" : "No");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    case 'Q':
                        {
                            #region Queues and Stacks
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine("Queues and Stacks");
                                string brackets = "{[()]}";
                                bool isBalanced = Challenges.ExploreQueuesAndStacks(brackets);
                                Console.WriteLine(isBalanced ? "YES" : "NO");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
                            #endregion
                        }
                        break;
                    default:
                        break;
                }

                function = GetUserInput();
            }
        }

        private static char GetUserInput()
        {
            Console.WriteLine("A - Anagrams");
            Console.WriteLine("B - Bubble Sort");
            Console.WriteLine("C - Comparer Implementation");
            Console.WriteLine("D - Detect Linked List Cycle");
            Console.WriteLine("F - Fibonacci series");
            Console.WriteLine("H - Hash Tables");
            Console.WriteLine("I - Lonely Integer");
            Console.WriteLine("L - Left shift");
            Console.WriteLine("M - Merge Sort");
            Console.WriteLine("P - Find Permutations");
            Console.WriteLine("Q - Balanced Brackets");
            Console.WriteLine("R - Implement Queue using stacks");
            Console.WriteLine("S - Search and Match strings");

            return char.ToUpper(Console.ReadKey().KeyChar);
        }

        private static void HandleError(Exception ex)
        {
            Console.WriteLine($"\n{ex.Message}");
        }
    }
}
