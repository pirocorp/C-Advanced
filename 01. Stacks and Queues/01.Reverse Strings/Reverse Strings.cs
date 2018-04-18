namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var charStack = new Stack<char>();

            foreach (var currentChar in input)
            {
                charStack.Push(currentChar);
            }

            Console.WriteLine(string.Join("", charStack));
        }
    }
}
