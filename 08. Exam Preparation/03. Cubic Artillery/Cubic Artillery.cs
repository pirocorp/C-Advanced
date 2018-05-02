namespace _03._Cubic_Artillery
{
    using System;
    using System.Collections.Generic;

    public class CubicArtillery
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<KeyValuePair<string, Queue<int>>>();
            var currentBunkerWeaponStorage = 0;

            var inputLine = Console.ReadLine();

            while (inputLine != "Bunker Revision")
            {
                var tokens = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < tokens.Length; i++)
                {
                    var element = tokens[i];
                    var isParsed = int.TryParse(element, out var parsedElement);

                    if (isParsed)
                    {
                        var topBunkerInQueue = queue.Peek();
                        
                        if (currentBunkerWeaponStorage <= n - parsedElement)
                        {
                            topBunkerInQueue.Value.Enqueue(parsedElement);
                            currentBunkerWeaponStorage += parsedElement;
                        }
                        else
                        {
                            if (queue.Count > 1)
                            {
                                PrintBunker(queue.Dequeue());
                                i--;
                                currentBunkerWeaponStorage = 0;
                                continue;
                            }
                            else
                            {
                                if (parsedElement <= n)
                                {
                                    var currentFreeCapacity = n - currentBunkerWeaponStorage;

                                    if (currentFreeCapacity >= parsedElement)
                                    {
                                        topBunkerInQueue.Value.Enqueue(parsedElement);
                                        currentBunkerWeaponStorage += parsedElement;
                                    }
                                    else
                                    {
                                        while (currentFreeCapacity < parsedElement)
                                        {
                                            currentBunkerWeaponStorage -= topBunkerInQueue.Value.Dequeue();
                                            currentFreeCapacity = n - currentBunkerWeaponStorage;
                                        }

                                        topBunkerInQueue.Value.Enqueue(parsedElement);
                                        currentBunkerWeaponStorage += parsedElement;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var newBunker = new KeyValuePair<string ,Queue<int>>(element, new Queue<int>());
                        queue.Enqueue(newBunker);
                    }
                }

                inputLine = Console.ReadLine();
            }
        }

        private static void PrintBunker(KeyValuePair<string, Queue<int>> bunker)
        {
            var bunkerName = bunker.Key;
            var bunkerWeapons = bunker.Value.ToArray();
            var bunkerWeaponsString = bunker.Value.ToArray().Length > 0 ? string.Join(", ", bunkerWeapons) : "Empty";

            Console.WriteLine($"{bunkerName} -> {bunkerWeaponsString}");
        }
    }
}
