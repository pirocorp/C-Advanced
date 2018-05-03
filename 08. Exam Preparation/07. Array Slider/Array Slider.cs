namespace _07._Array_Slider
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class ArraySlider
    {
        private static int currentPosition = 0;

        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split("\r\n\t\f\v ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            var inputLine = Console.ReadLine();

            while (inputLine != "stop")
            {
                var tokens = inputLine.Split(new []{' '}).ToArray();

                var offset = int.Parse(tokens[0]);
                var operation = tokens[1];
                var operand = int.Parse(tokens[2]);

                currentPosition += offset;
                currentPosition = currentPosition % numbers.Length;

                if (currentPosition < 0)
                {
                    currentPosition = numbers.Length + currentPosition;
                }

                var currentElement = numbers[currentPosition];
                currentElement = ProcessCommand(currentElement, operation, operand);
                numbers[currentPosition] = currentElement;

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static BigInteger ProcessCommand(BigInteger currentElement, string operation, int operand)
        {
            switch (operation)
            {
                case "&":
                    currentElement = currentElement & operand;
                    break;
                case "|":
                    currentElement = currentElement | operand;
                    break;
                case "^":
                    currentElement = currentElement ^ operand;
                    break;
                case "+":
                    currentElement = currentElement + operand;
                    break;
                case "-":
                    currentElement = currentElement - operand < 0 ? 0 : currentElement - operand;
                    break;
                case "*":
                    currentElement = currentElement * operand;
                    break;
                case "/":
                    currentElement = currentElement / operand;
                    break;
            }

            return currentElement;
        }

        private static void PrintArryPointer(int[] numbers, int i)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine($"{new string(' ', 2 * i)}|");
        }
    }
}
