using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class HandHelper
    {
        public int GetRankSum(List<Card> cards)
        {
            int sum = 0;

            foreach (var c in cards)
                sum += (int)c.Rank;

            return sum;
        }
    }
}
