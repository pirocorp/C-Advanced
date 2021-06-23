namespace _06._Wardrobe
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var color = tokens[0];
                var items = tokens[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var item in items)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }

                    wardrobe[color][item]++;
                }
            }

            var searchTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var searchColor = searchTokens[0];
            var searchItem = searchTokens[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    var itemsString = $"* {item.Key} - {item.Value}";

                    if (color.Key == searchColor && item.Key == searchItem)
                    {
                        itemsString += " (found!)";
                    }

                    Console.WriteLine(itemsString);   
                }
            }
        }
    }
}
