namespace _09._Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Program
    {
        public static void Main()
        {
            UpgradeSolution();
        }

        private static void UpgradeSolution()
        {
            var n = int.Parse(Console.ReadLine());

            var resultStack = new Stack<string>(1024);

            var sb = new StringBuilder();

            resultStack.Push(sb.ToString());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                switch (command)
                {
                    case "1":
                        sb.Append(tokens[1]);

                        resultStack.Push(sb.ToString());
                        break;
                    case "2":
                        var count = int.Parse(tokens[1]);

                        var length = sb.Length;
                        sb.Remove(length - count, count);

                        resultStack.Push(sb.ToString());
                        break;
                    case "3":
                        var index = int.Parse(tokens[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;
                    case "4":
                        sb.Clear();
                        resultStack.Pop();
                        sb.Append(resultStack.Peek());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
