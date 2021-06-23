namespace _11._Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(ReadSpaceSeparatedCollection<int>().ToList());
            var locks = new Queue<int>(ReadSpaceSeparatedCollection<int>());
            var intelligence = int.Parse(Console.ReadLine());

            var initialBulletsCount = bullets.Count;

            var currentBarrel = barrelSize;

            while (bullets.Any() && locks.Any())
            {
                var bullet = bullets.Pop();
                currentBarrel--;

                if (bullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currentBarrel == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    currentBarrel = barrelSize;
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                return;
            }

            var moneyEarned = intelligence - (initialBulletsCount - bullets.Count) * bulletPrice;

            Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
        }

        private static IEnumerable<T> ReadSpaceSeparatedCollection<T>()
            => Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => (T)Convert.ChangeType(x, typeof(T)));
    }
}
