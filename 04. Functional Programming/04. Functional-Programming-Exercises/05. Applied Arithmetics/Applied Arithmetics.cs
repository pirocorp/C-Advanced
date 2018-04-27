namespace _05._Applied_Arithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var command = Console.ReadLine();

            while (command != "end")
            {
                Func<int, int> operation = null;

                if (command != "print")
                {
                    operation = GetOperationFunction(command);
                    numbers = numbers.Select(x => operation(x)).ToArray();
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                command = Console.ReadLine();
            }
        }

        private static Func<int, int> GetOperationFunction(string command)
        {
            switch (command)
            {
                case "add": 
                    return x => x + 1;
                case "multiply":
                    return x => x * 2;
                case "subtract":
                    return x => x - 1;
                default:
                    return null;
            }
        }
    }
}
