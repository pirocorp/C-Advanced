namespace _30._Number_Wars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        private const int maxCounter = 1000000;

        public static void Main()
        {
            var firstAllCards = new Queue<string>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            var secondAllCards = new Queue<string>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            var turnCounter = 0;
            var gameOver = false;

            while (turnCounter < maxCounter && 
                   firstAllCards.Count > 0 && 
                   secondAllCards.Count > 0 &&
                   !gameOver)
            {
                turnCounter++;

                var playerOneCard = firstAllCards.Dequeue();
                var playerTwoCard = secondAllCards.Dequeue();

                var compareResult = GetNumberValue(playerOneCard).CompareTo(GetNumberValue(playerTwoCard));

                if (compareResult == 1)
                {
                    firstAllCards.Enqueue(playerOneCard);
                    firstAllCards.Enqueue(playerTwoCard);
                }
                else if(compareResult == -1)
                {
                    secondAllCards.Enqueue(playerTwoCard);
                    secondAllCards.Enqueue(playerOneCard);
                }
                else
                {
                    var cardsHand = new List<string>{ playerOneCard, playerTwoCard };

                    while (!gameOver)
                    {
                        if (firstAllCards.Count >= 3 && secondAllCards.Count >= 3)
                        {
                            var firstSum = 0;
                            var secondSum = 0;

                            for (var i = 0; i < 3; i++)
                            {
                                var firstCard = firstAllCards.Dequeue();
                                var secondCard = secondAllCards.Dequeue();

                                firstSum += GetCharValue(firstCard);
                                secondSum += GetCharValue(secondCard);

                                cardsHand.Add(firstCard);
                                cardsHand.Add(secondCard);
                            }

                            var comparison = firstSum.CompareTo(secondSum);

                            if (comparison == 1)
                            {
                                AddArrayToQueue(firstAllCards, cardsHand);
                                break;
                            }

                            if (comparison == -1)
                            {
                                AddArrayToQueue(secondAllCards, cardsHand);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                            break;
                        }
                    }
                }
            }

            var result = string.Empty;

            var allCards = firstAllCards.Count.CompareTo(secondAllCards.Count);

            if (allCards == 0)
            {
                result = "Draw";
            }
            else if(allCards == 1)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }

            Console.WriteLine($"{result} after {turnCounter} turns");
        }

        private static void AddArrayToQueue(Queue<string> queue, List<string> list)
        {
            foreach (var item in list
                .OrderByDescending(GetNumberValue)
                .ThenByDescending(GetCharValue))
            {
                queue.Enqueue(item);
            }
        }

        private static int GetCharValue(string v)
        {
            return v.Last();
        }

        private static int GetNumberValue(string firstPlayerCard)
        {
            return int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
        }
    }
}
