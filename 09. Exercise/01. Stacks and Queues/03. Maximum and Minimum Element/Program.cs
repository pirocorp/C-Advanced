namespace _03._Maximum_and_Minimum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static readonly Stack<int> stack = new Stack<int>();

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                ProcessInput(input);
            }

            Console.WriteLine(string.Join(", ", stack));
        }

        private static void ProcessInput(string input)
        {
            var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = int.Parse(tokens[0]);

            switch (command)
            {
                case 1:
                    var element = int.Parse(tokens[1]);
                    stack.Push(element);
                    break;
                case 2:
                    stack.Pop();
                    break;
                case 3:
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.OrderByDescending(x => x).First());
                    }
                    break;
                case 4:
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.OrderBy(x => x).First());
                    }
                    break;
            }
        }
    }
}
