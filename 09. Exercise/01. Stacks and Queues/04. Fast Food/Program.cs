namespace _04._Fast_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            var food = int.Parse(Console.ReadLine());

            ProcessInput(queue);

            var max = queue.Max(x => x);

            while (queue.Any())
            {
                if (queue.Peek() <= food)
                {
                    food -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(max);

            if (queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }

        private static void ProcessInput(Queue<int> queue)
        {
            var orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            foreach (var order in orders)
            {
                queue.Enqueue(order);
            }
        }
    }
}
