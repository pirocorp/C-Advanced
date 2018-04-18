namespace _01.Reverse_Strings
{
    using System;
    using System.Collections.Generic;

    public class ReverseStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            //var charStack = new Stack<char>();
            
            //foreach (var currentChar in input)
            //{
            //    charStack.Push(currentChar);
            //}

            var charStack = new Stack<char>(input);

            Console.WriteLine(string.Join("", charStack));
        }
    }
}
