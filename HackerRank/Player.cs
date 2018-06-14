using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class Player : IComparable<Player>
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public int CompareTo(Player player)
        {
            var result = -(Score.CompareTo(player.Score));

            if (result == 0)
            {
                return Name.CompareTo(player.Name);
            }

            return result;
        }
    }

    public class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
           return x.CompareTo(y);
        }
    }
}
