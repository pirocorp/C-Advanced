namespace _05._Cubic_Assault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicAssault
    {
        public static void Main()
        {
            var meteorsByRegionAndType = ReadInputData();

            var result = meteorsByRegionAndType
                .OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var region in result)
            {
                var regionName = region.Key;
                var regionMeteors = region.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{regionName}");

                foreach (var meteor in regionMeteors)
                {
                    var meteorType = meteor.Key;
                    var meteorCount = meteor.Value;

                    Console.WriteLine($"-> {meteorType} : {meteorCount}");
                }
            }
        }

        private static Dictionary<string, Dictionary<string, long>> ReadInputData()
        {
            var meteorsByRegionAndType = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input != "Count em all")
            {
                var tokens = input.Split(new[] {"->"}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var regionName = tokens[0];
                var meteorType = tokens[1];
                var count = int.Parse(tokens[2]);

                if (!meteorsByRegionAndType.ContainsKey(regionName))
                {
                    meteorsByRegionAndType[regionName] = new Dictionary<string, long>
                    {
                        { "Red", 0L },
                        { "Black", 0L },
                        { "Green", 0L }
                    };
                }

                switch (meteorType)
                {
                    case "Green":
                        if (count + meteorsByRegionAndType[regionName]["Green"] >= 1000000)
                        {
                            var valueCurrentMeteor = (count + meteorsByRegionAndType[regionName]["Green"]) % 1000000;
                            var nextMeteor = (count + meteorsByRegionAndType[regionName]["Green"]) / 1000000;
                            meteorsByRegionAndType[regionName]["Green"] = valueCurrentMeteor;

                            meteorsByRegionAndType[regionName]["Red"] += nextMeteor;

                            if (meteorsByRegionAndType[regionName]["Red"] >= 1000000)
                            {
                                valueCurrentMeteor = meteorsByRegionAndType[regionName]["Red"] % 1000000;
                                nextMeteor = meteorsByRegionAndType[regionName]["Red"] / 1000000;
                                meteorsByRegionAndType[regionName]["Red"] = valueCurrentMeteor;

                                meteorsByRegionAndType[regionName]["Black"] += nextMeteor;
                            }
                        }
                        else
                        {
                            meteorsByRegionAndType[regionName]["Green"] += count;
                        }

                        break;
                    case "Red":
                        if (count + meteorsByRegionAndType[regionName]["Red"] >= 1000000)
                        {
                            var valueCurrentMeteor = (count + meteorsByRegionAndType[regionName]["Red"]) % 1000000;
                            var nextMeteor = (count + meteorsByRegionAndType[regionName]["Red"]) / 1000000;
                            meteorsByRegionAndType[regionName]["Red"] = valueCurrentMeteor;
                            meteorsByRegionAndType[regionName]["Black"] += nextMeteor;
                        }
                        else
                        {
                            meteorsByRegionAndType[regionName]["Red"] += count;
                        }

                        break;
                    case "Black":
                        meteorsByRegionAndType[regionName]["Black"] += count;
                        break;
                }

                input = Console.ReadLine();
            }

            return meteorsByRegionAndType;
        }
    }
}
