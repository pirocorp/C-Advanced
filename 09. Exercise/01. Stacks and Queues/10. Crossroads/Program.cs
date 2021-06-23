namespace _10._Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static int total = 0;

        private static bool crash = false;

        public static void Main()
        {
            var duration = int.Parse(Console.ReadLine());

            var freeWindow = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            string input;

            while ((input = Console.ReadLine()) != "END" && !crash)
            {
                if (input == "green")
                {
                    ProcessJunction(duration, freeWindow, queue);
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            if (!crash)
            {
                Console.WriteLine($"Everyone is safe.");
                Console.WriteLine($"{total} total cars passed the crossroads.");
            }
        }

        private static void ProcessJunction(int duration, int freeWindow, Queue<string> queue)
        {
            while (queue.Any() && duration >= queue.Peek().Length)
            {
                var car = queue.Dequeue();
                total++;
                duration -= car.Length;
            }

            if (duration > 0 && queue.Any()) // Possible wrong
            {
                var car = queue.Dequeue();

                var totalTime = duration + freeWindow;

                if (totalTime < car.Length)
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{car} was hit at {car[totalTime]}.");
                    crash = true;
                    return;
                }

                total++;
            }
        }
    }
}
