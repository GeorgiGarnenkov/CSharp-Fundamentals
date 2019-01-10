using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NumberWars
{
    class NumberWars
    {
        const int MaxCounter = 1_000_000;
        static void Main()
        {
            Queue<string> firstPlayerCards = new Queue<string>
                (Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            Queue<string> secondPlayerCards = new Queue<string>
            (Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            var turns = 0;
            bool gameOver = false;
            while (turns < MaxCounter && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && !gameOver)
            {
                turns++;
                var firstCard = firstPlayerCards.Dequeue();
                var secondCard = secondPlayerCards.Dequeue();

                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstPlayerCards.Enqueue(firstCard);
                    firstPlayerCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard) < GetNumber(secondCard))
                {
                    secondPlayerCards.Enqueue(secondCard);
                    secondPlayerCards.Enqueue(firstCard);
                }
                else
                {
                    List<string> cardsHand = new List<string> { firstCard, secondCard };

                    while (!gameOver)
                    {
                        if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;

                            for (int counter = 0; counter < 3; counter++)
                            {
                                var firstHandCard = firstPlayerCards.Dequeue();
                                var secondHandCard = secondPlayerCards.Dequeue();

                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);

                                cardsHand.Add(firstHandCard);
                                cardsHand.Add(secondHandCard);
                            }

                            var comparison = firstSum.CompareTo(secondSum);

                            if (comparison.Equals(1))
                            {
                                AddCardsToWinner(cardsHand, firstPlayerCards);
                                break;
                            }
                            else if (comparison.Equals(-1))
                            {
                                AddCardsToWinner(cardsHand, secondPlayerCards);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            var result = "";
            if (firstPlayerCards.Count == secondPlayerCards.Count)
            {
                result = "Draw";
            }
            else if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }
            
            Console.WriteLine($"{result} after {turns} turns");

        }

        private static void AddCardsToWinner(List<string> cardsHand, Queue<string> PlayerCards)
        {
            foreach (var card in cardsHand.OrderByDescending(a => GetNumber(a)).ThenByDescending(c => GetChar(c)))
            {
                PlayerCards.Enqueue(card);
            }
        }

        static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
