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
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var count = 0;

            while (true)
            {
                var currentPlants = plants;
                plants = SepareteDeathFromAlivePlants(currentPlants);
                

                if (plants.Count >= currentPlants.Count)
                {
                    break;
                }

                count++;
                //Console.WriteLine($"{string.Join(", ", plants)} -> Day: {count}");
            }

            Console.WriteLine(count);
        }

        private static List<int> SepareteDeathFromAlivePlants(List<int> currentPlants)
        {
            var alivePlants = new List<int>();

            alivePlants.Add(currentPlants[0]);

            for (var i = 1; i < currentPlants.Count; i++)
            {
                var previusPlant = currentPlants[i - 1];
                var crrentPlant = currentPlants[i];

                if (crrentPlant <= previusPlant)
                {
                    alivePlants.Add(crrentPlant);
                }
            }

            return alivePlants;
        }
    }
}
