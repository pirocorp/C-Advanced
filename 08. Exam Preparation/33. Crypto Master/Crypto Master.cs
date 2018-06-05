namespace _33._Crypto_Master
{
    using System;
    using System.Linq;

    public class CryptoMaster
    {
        private static int[] Numbers;

        public static void Main()
        {
            Numbers = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var maxLenght = 0;

            for (var currentStepSize = 0; currentStepSize < Numbers.Length; currentStepSize++)
            {
                for (var startIndex = 0; startIndex < Numbers.Length; startIndex++)
                {
                    var sequenceLenght = RotateNumbersByStep(startIndex, currentStepSize);

                    if (sequenceLenght > maxLenght)
                    {
                        maxLenght = sequenceLenght;
                    }
                }
            }

            Console.WriteLine(maxLenght);
        }

        private static int RotateNumbersByStep(int startIndex, int currentStepSize)
        {
            var lenght = 1;
            var numbersCount = Numbers.Length;

            while (true)
            {

                var currentElement = Numbers[startIndex];
                var nextElementIndex = (startIndex + currentStepSize) % numbersCount;
                var nextElement = Numbers[nextElementIndex];

                if (currentElement >= nextElement)
                {
                    break;
                }

                currentElement = nextElement;
                startIndex = nextElementIndex;

                lenght++;
            }

            return lenght;
        }
    }
}
