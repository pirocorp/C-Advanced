namespace _34._Greedy_Times
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class GreedyTimes
    {
        public static void Main()
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var bagContent = new Dictionary<string, Dictionary<string, long>>();

            var currentGoldAmount = 0L;
            var currentGemAmount = 0L;
            var currentCashAmount = 0L;

            for (var i = 0; i < tokens.Length; i+=2)
            {
                var currentAsset = tokens[i];
                var currentAssetValue = long.Parse(tokens[i + 1]);
                var currentAssetType = string.Empty;

                if (currentAsset.Length == 3 && currentAsset.Trim().All(char.IsLetter))
                {
                    if (currentGemAmount >= currentCashAmount + currentAssetValue && bagCapacity >= currentCashAmount + currentGemAmount + currentGoldAmount + currentAssetValue)
                    {
                        currentAssetType = "Cash";
                        currentCashAmount += currentAssetValue;
                    }
                }

                if (currentAsset.ToLower().Trim().EndsWith("gem") && currentAsset.Length >= 4)
                {
                    if (currentGoldAmount >= currentGemAmount + currentAssetValue && bagCapacity >= currentCashAmount + currentGemAmount + currentGoldAmount + currentAssetValue)
                    {
                        currentAssetType = "Gem";
                        currentGemAmount += currentAssetValue;
                    }
                }

                if (currentAsset.ToLower().Trim() == "gold")
                {
                    if (bagCapacity >= currentCashAmount + currentGemAmount + currentGoldAmount + currentAssetValue)
                    {
                        currentAssetType = "Gold";
                        currentGoldAmount += currentAssetValue;
                    }
                }

                if (currentAssetType != string.Empty)
                {
                    if (!bagContent.ContainsKey(currentAssetType))
                    {
                        bagContent[currentAssetType] = new Dictionary<string, long>();
                    }

                    if (!bagContent[currentAssetType].ContainsKey(currentAsset))
                    {
                        bagContent[currentAssetType][currentAsset] = 0;
                    }

                    bagContent[currentAssetType][currentAsset] += currentAssetValue;
                }
            }

            bagContent = bagContent
                .OrderByDescending(x => x.Value.Sum(s => s.Value))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var itemType in bagContent)
            {
                var itemTypeName = itemType.Key;
                var itemTypeTotalAmount = itemType.Value.Sum(x => x.Value);

                Console.WriteLine($"<{itemTypeName}> ${itemTypeTotalAmount}");

                var itemsFromCurrentType = itemType.Value
                    .OrderByDescending(x => x.Key)
                    .ThenBy(x => x.Value);

                foreach (var item in itemsFromCurrentType)
                {
                    var itemName = item.Key;
                    var itemValue = item.Value;

                    Console.WriteLine($"##{itemName} - {itemValue}");
                }
            }
        }
    }
}
