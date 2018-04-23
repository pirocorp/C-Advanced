namespace _10.The_Heigan_Dance
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var damage = double.Parse(Console.ReadLine());

            var playerHealth = 18500D;
            var heiganHealth = 3000000D;

            var playerCordinates = new[] {7, 7};

            var isPoisoned = false;
            var killedBy = string.Empty;

            while (playerHealth > 0 && heiganHealth > 0)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var spell = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);

                heiganHealth -= damage;

                var playerIsHit = false;

                if (heiganHealth > 0)
                {
                    playerIsHit = ProcessPlayerCordiantes(row, col, playerCordinates);
                }
                
                if (isPoisoned)
                {
                    playerHealth -= 3500;
                    isPoisoned = false;

                    if (playerHealth <= 0)
                    {
                        killedBy = "Plague Cloud";
                        break;
                    }
                }

                if (spell == "Cloud" && playerHealth > 0 && playerIsHit)
                {
                    playerHealth -= 3500;
                    isPoisoned = true;

                    if (playerHealth <= 0)
                    {
                        killedBy = "Plague Cloud";
                        break;
                    }
                }

                if (spell == "Eruption" && playerHealth > 0 && playerIsHit)
                {
                    playerHealth -= 6000;

                    if (playerHealth <= 0)
                    {
                        killedBy = "Eruption";
                        break;
                    }
                }
            }

            if (heiganHealth <= 0)
            {
                Console.WriteLine($"Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHealth:F2}");
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine($"Player: Killed by {killedBy}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHealth}");
            }

            Console.WriteLine($"Final position: {playerCordinates[0]}, {playerCordinates[1]}");
        }

        private static bool ProcessPlayerCordiantes(int row, int col, int[] playerCordinates)
        {
            var maxRowIndex = Math.Min(14, row + 1);
            var minRowIndex = Math.Max(0, row - 1);

            var maxColIndex = Math.Min(14, col + 1);
            var minColIndex = Math.Max(0, col - 1);

            var currentLevel = LevelInitializer();

            for (var rowIndex = minRowIndex; rowIndex <= maxRowIndex; rowIndex++)
            {
                for (var colIndex = minColIndex; colIndex <= maxColIndex; colIndex++)
                {
                    currentLevel[rowIndex][colIndex] = true;
                }
            }

            if (CantPlayerEscape(currentLevel, playerCordinates))
            {
                return true;
            }

            return false;
        }

        private static bool CantPlayerEscape(bool[][] currentLevel, int[] playerCordinates)
        {
            var row = playerCordinates[0];
            var col = playerCordinates[1];

            var tryUp = Math.Max(0, row - 1);
            var tryDown = Math.Min(14, row + 1);
            var tryRight = Math.Min(14, col + 1);
            var tryLeft = Math.Max(0, col - 1);

            if (currentLevel[row][col])
            {
                if (currentLevel[tryUp][col] &&
                    currentLevel[tryDown][col] &&
                    currentLevel[row][tryLeft] &&
                    currentLevel[row][tryRight])
                {
                    return true;
                }
                else
                {
                    if (!currentLevel[tryUp][col])
                    {
                        playerCordinates[0]--;
                    }
                    else if (!currentLevel[row][tryRight])
                    {
                        playerCordinates[1]++;
                    }
                    else if (!currentLevel[tryDown][col])
                    {
                        playerCordinates[0]++;
                    }
                    else if(!currentLevel[row][tryLeft])
                    {
                        playerCordinates[1]--;
                    }

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static bool[][] LevelInitializer()
        {
            var level = new bool [15][];

            for (var rowIndex = 0; rowIndex < level.Length; rowIndex++)
            {
                level[rowIndex] = new bool [15];
            }

            return level;
        }
    }
}
