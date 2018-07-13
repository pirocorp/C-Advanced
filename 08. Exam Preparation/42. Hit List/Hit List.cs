using System.Linq;

namespace _42._Hit_List
{
    using System;
    using System.Collections.Generic;


    public class HitList
    {
        public static void Main()
        {
            var targets = new Dictionary<string, Dictionary<string, string>>();
            var targetInfoIndex = int.Parse(Console.ReadLine());

            var inputLine = Console.ReadLine();

            while (inputLine != "end transmissions")
            {
                var tokens = inputLine.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                var targetName = tokens[0];

                if (!targets.ContainsKey(targetName))
                {
                    targets[targetName] = new Dictionary<string, string>();
                }
                    
                var kvpList = tokens[1].Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var kvp in kvpList)
                {
                    var kvpTokens = kvp.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    var key = kvpTokens[0];
                    var value = kvpTokens[1];

                    targets[targetName][key] = value;
                }

                inputLine = Console.ReadLine();
            }

            var killCommand = Console.ReadLine();
            var killTokens = killCommand.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var name = killTokens[1];

            var targetInfo = targets[name]
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Info on {name}:");

            foreach (var kvp in targetInfo)
            {
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            var infoIndex = targetInfo.Sum(x => x.Key.Length) + targetInfo.Sum(x => x.Value.Length);

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine($"Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
