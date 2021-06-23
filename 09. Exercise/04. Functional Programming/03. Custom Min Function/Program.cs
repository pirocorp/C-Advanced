namespace _03._Custom_Min_Function
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minElement = GetMin;

            Console.WriteLine(minElement(numbers));
        }

        private static int GetMin(int[] numbers)
        {
            var min = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                }
            }

            return min;
        }
    }
}
