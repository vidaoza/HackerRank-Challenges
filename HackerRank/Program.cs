using System;
using System.Collections.Generic;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            char function = 'L';

            while (function != 'X')
            {
                Console.WriteLine();
                switch (function)
                {
                    case 'L':
                        {
                            int[] originalArray = new[] { 1, 2, 3, 4, 5 };
                            int[] shiftedArray = Challenges.ArraysLeftRotation(originalArray, 4);

                            for (int i = 0; i < shiftedArray.Length; i++)
                                Console.Write($"{shiftedArray[i]} ");

                            Console.WriteLine();
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Press 'L' for the Left shift function");
                function = char.ToUpper(Console.ReadKey().KeyChar);
            }
        }

    }
}
