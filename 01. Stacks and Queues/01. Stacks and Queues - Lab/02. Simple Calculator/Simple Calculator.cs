namespace _02.Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Reverse();

            var stringStack = new Stack<string>(input);

            while (stringStack.Count > 1)
            {
                var first = int.Parse(stringStack.Pop());
                var op = stringStack.Pop();
                var second = int.Parse(stringStack.Pop());

                switch (op)
                {
                    case "+":
                        stringStack.Push((first + second).ToString());
                        break;
                    case "-":
                        stringStack.Push((first - second).ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stringStack.Pop());
        }
    }
}
