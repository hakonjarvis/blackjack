using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public Queue<Card> Cards;
        public Queue<Card> ShuffledCards;
        public Deck()
        {
            Cards = new Queue<Card>();
            ShuffledCards = new Queue<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                //for (int i = 2; i < 14; i++)
                //{
                //    Cards.Enqueue(new Card() { Rank = (Rank) i, Suit = suit });
                //}
                foreach (var r in Enum.GetValues(typeof(Rank)))
                {
                    if (r.Equals(Rank.One))
                        continue;

                    Cards.Enqueue(new Card() { Rank = (Rank)r, Suit = suit });
                }
            }
                        
            var range = Enumerable.Range(0, 51).OrderBy(x => Guid.NewGuid()).ToList();

            foreach(int r in range)
            {
                ShuffledCards.Enqueue(Cards.ToArray()[r]);
            }
        }
    }
}
