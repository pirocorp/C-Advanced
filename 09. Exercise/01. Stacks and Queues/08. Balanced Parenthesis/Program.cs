namespace _08._Balanced_Parenthesis
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            var inputParenthesis = Console.ReadLine().ToCharArray();
            var stackOfParenthesis = new Stack<char>();

            foreach (var item in inputParenthesis)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    stackOfParenthesis.Push(item);
                    continue;
                }

                if (stackOfParenthesis.Count == 0 || !IsClosingParenthesisToCurrentParenthesis(stackOfParenthesis.Peek(), item))
                {
                    Console.WriteLine("NO");
                    return;
                }

                stackOfParenthesis.Pop();
            }

            if (stackOfParenthesis.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool IsClosingParenthesisToCurrentParenthesis(char openParenthesis, char closingParenthesis)
        {
            switch (openParenthesis)
            {
                case '{':
                    if (closingParenthesis == '}')
                    {
                        return true;
                    }
                    break;
                case '[':
                    if (closingParenthesis == ']')
                    {
                        return true;
                    }
                    break;
                case '(':
                    if (closingParenthesis == ')')
                    {
                        return true;
                    }
                    break;
                default: return false;
            }

            return false;
        }
    }
}
