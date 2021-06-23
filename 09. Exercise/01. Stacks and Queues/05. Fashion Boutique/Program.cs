namespace _05._Fashion_Boutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var stack = new Stack<int>(tokens);

            var rackSize = int.Parse(Console.ReadLine());
            var currentRack = rackSize;

            var totalRacks = 1;

            while (stack.Any())
            {
                if (currentRack >= stack.Peek())
                {
                    currentRack -= stack.Pop();
                }
                else
                {
                    currentRack = rackSize;
                    totalRacks++;
                }
            }

            Console.WriteLine(totalRacks);
        }
    }
}
