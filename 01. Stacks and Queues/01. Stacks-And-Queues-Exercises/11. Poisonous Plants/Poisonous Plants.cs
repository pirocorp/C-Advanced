namespace _11.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            var numberOfPlants = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var days = new int[plants.Length];

            var indexOfPlants = new Stack<int>();
            indexOfPlants.Push(0);

            for (var i = 1; i < plants.Length; i++)
            {
                var maxDays = 0;

                while (indexOfPlants.Count > 0 && plants[indexOfPlants.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(days[indexOfPlants.Pop()], maxDays);
                }

                if (indexOfPlants.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indexOfPlants.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}