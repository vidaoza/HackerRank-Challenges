using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            char function = 'A';// GetUserInput();

            while (function != 'X')
            {
                Console.WriteLine();
                switch (function)
                {
                    case 'A':
                        {
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
                        }
                        break;
                    case 'L':
                        {
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
                        }
                        break;
                    case 'M':
                        {
                            try
                            {
                                Console.WriteLine("*****************************************************************");
                                Console.WriteLine($"Check Magazine");
                                string magazine = "grand give me one grand today me night";
                                string note = "one give one grand today one";

                                bool canMakeNote = Challenges.CheckMagazine(magazine, note);
                                Console.WriteLine(canMakeNote? "Yes" : "No");
                                Console.WriteLine("\n*****************************************************************");
                            }
                            catch (Exception ex)
                            {
                                HandleError(ex);
                            }
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
            Console.WriteLine("L - Left shift");
            Console.WriteLine("M - Magazine Check");

            return char.ToUpper(Console.ReadKey().KeyChar);
        }

        private static void HandleError(Exception ex)
        {
            Console.WriteLine($"\n{ex.Message}");
        }
    }
}
