namespace _06._Songs_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());

            var queue = new Queue<string>(songs);

            while (queue.Any())
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var command = tokens[0];

                switch (command)
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Add":
                        var song = string.Join(" ", tokens.Skip(1));

                        if (queue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            queue.Enqueue(song);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", queue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
