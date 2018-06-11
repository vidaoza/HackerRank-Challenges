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

        internal static bool CheckMagazine(string magazine, string note)
        {
            var noteArray = note.Split(' ');
            var dictionary = magazine.Split(' ').GroupBy(s => s)
                .ToDictionary(g => g.Key, g => g.Count());
            var canMakeMessage = true;
            var count = 0;
            while (canMakeMessage && count < noteArray.Length)
            {
                canMakeMessage = dictionary.ContainsKey(noteArray[count]) && dictionary[noteArray[count]] > 0;
                dictionary[noteArray[count]]--;
                count++;
            }
            return canMakeMessage;
        }
    }
}
