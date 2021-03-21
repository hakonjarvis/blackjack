using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();

            var hand = new List<Card>();

            var dealerHand = new List<Card>();
            var dealerTotal = 0;
            var playerTotal = 0;


            while (true)
            {
                if (dealerHand.Count == 0)
                {
                    var dealerFirstCard = deck.ShuffledCards.Dequeue();
                    dealerHand.Add(dealerFirstCard);
                    //dealerTotal = dealerHand.Sum(x => Math.Min((int)x.Rank, 10));
                    dealerTotal += (int)dealerFirstCard.Rank;
                    Console.WriteLine($"Dealer pulled hes (hens på norsk, ja...) first card: {dealerFirstCard.Suit}, {dealerFirstCard.Rank}");
                    Console.WriteLine($"Now it's your turn!");
                }

                Console.WriteLine("Stand or Hit?");
                string read = Console.ReadLine();
                if (read.ToLower() == "hit")
                {
                    var card = deck.ShuffledCards.Dequeue();

                    if (card.Rank.ToString().Equals(Rank.A.ToString()) && playerTotal >= 10)
                    {
                        Console.WriteLine($"You pulled a A but the total is above ten -> value is treated as 1");
                        card.Rank = Rank.One;
                    }


                    hand.Add(card);
                    //var total = hand.Sum(x => Math.Min(x.Rank, 10));
                    playerTotal += (int)card.Rank;


                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.Rank, playerTotal);

                    if (playerTotal > 21)
                    {
                        Console.WriteLine($"You lost, your total is {playerTotal})");

                        break;
                    }
                }
                else if (read.ToLower() == "stand")
                {
                    
                    if (dealerTotal> playerTotal)
                    {
                        Console.WriteLine($"You lost! Dealer total score {dealerTotal}, your total score {playerTotal}");
                        break;
                    }

                    while (true)
                    {
                        if (dealerTotal >= 17)
                        {
                            Console.WriteLine($"Dealer stops here with a total score of {dealerTotal}.");

                            if (dealerTotal < playerTotal || dealerTotal > 21)
                                Console.WriteLine($"You've won!");
                            else
                                Console.WriteLine($"You've lost...");
                            
                            return;
                        }

                        var dealerCard = deck.ShuffledCards.Dequeue();

                        if (dealerCard.Rank.ToString().Equals(Rank.A.ToString()) && dealerTotal >= 10)
                        {
                            Console.WriteLine($"Dealer pulled a A but the total is above ten -> value is treated as 1");
                            dealerCard.Rank = Rank.One;
                        }

                        Console.WriteLine($"Dealer pulled {dealerCard.Suit}, {dealerCard.Rank}.");

                        dealerHand.Add(dealerCard);
                        dealerTotal += (int)dealerCard.Rank;
                    }
                }
            }
        }
    }
}
