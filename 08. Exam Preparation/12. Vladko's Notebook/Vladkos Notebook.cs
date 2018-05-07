using System.Linq;

namespace _12._Vladko_s_Notebook
{
    using System;
    using System.Collections.Generic;

    public class VladkoNotebook
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var colors = new List<Color>();

            while (input != "END")
            {
                var tokens = input.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

                var color = tokens[0];

                if (!colors.Any(x => x.ColorName == color))
                {
                    var newColor = new Color(color);
                    colors.Add(newColor);
                }

                var currentColor = colors.First(x => x.ColorName == color);

                if (tokens[1] == "win")
                {
                    currentColor.CountWins++;
                    currentColor.Opponents.Add(tokens[2]);
                }
                else if (tokens[1] == "loss")
                {
                    currentColor.CountLosses++;
                    currentColor.Opponents.Add(tokens[2]);
                }
                else if (tokens[1] == "age")
                {
                    currentColor.Age = int.Parse(tokens[2]);
                }
                else if (tokens[1] == "name")
                {
                    currentColor.Name = tokens[2];
                }

                input = Console.ReadLine();
            }

            var result = colors
                .Where(x => x.Age != null && !string.IsNullOrEmpty(x.Name))
                .OrderBy(x => x.ColorName)
                .ToArray();

            if (result.Length <= 0)
            {
                Console.WriteLine($"No data recovered.");
            }

            foreach (var color in result)
            {
                var colorName = color.ColorName;
                var age = color.Age;
                var name = color.Name;
                var oponents = color.Opponents;
                oponents.Sort(StringComparer.Ordinal);
                var oponentsString = oponents.Count > 0 ? string.Join(", ", oponents) : "(empty)";
                var rank = color.Rank;

                Console.WriteLine($"Color: {colorName}");
                Console.WriteLine($"-age: {age}");
                Console.WriteLine($"-name: {name}");
                Console.WriteLine($"-opponents: {oponentsString}");
                Console.WriteLine($"-rank: {rank:F2}");
            }
        }
    }

    public class Color
    {
        public string ColorName { get; set; }

        public int? Age { get; set; }

        public string Name { get; set; }

        public List<string> Opponents { get; set; }

        public int CountWins { get; set; }

        public int CountLosses { get; set; }

        public double Rank => (CountWins + 1) / (double)(CountLosses + 1);

        public Color(string colorName)
        {
            ColorName = colorName;
            Opponents = new List<string>();
            CountWins = 0;
            CountLosses = 0;
        }
    }
}
