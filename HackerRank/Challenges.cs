using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    static class Challenges
    {
        public static int[] ArraysLeftRotation(
            int[] array,
            int noOfRotations)
        {
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
    }
}
