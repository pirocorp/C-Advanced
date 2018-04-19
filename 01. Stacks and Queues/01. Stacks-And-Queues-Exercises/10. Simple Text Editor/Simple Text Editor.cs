namespace _10.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var resultStack = new Stack<string>();
            resultStack.Push(string.Empty);

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                switch (command)
                {
                    case "1":
                        var currentText = resultStack.Peek();

                        currentText += tokens[1];

                        resultStack.Push(currentText);
                        break;
                    case "2":
                        currentText = resultStack.Peek();

                        var count = int.Parse(tokens[1]);
                        currentText = DeleteLastElements(currentText, count);

                        resultStack.Push(currentText);
                        break;
                    case "3":
                        currentText = resultStack.Peek();
                        var index = int.Parse(tokens[1]);

                        var currentChar = currentText[index - 1];

                        Console.WriteLine(currentChar);
                        break;
                    case "4":
                        resultStack.Pop();
                        break;
                    default:
                        break;
                }
            }
        }

        private static string DeleteLastElements(string text, int count)
        {
            text = ReverseString(text).Substring(count);

            return ReverseString(text);
        }

        private static string ReverseString(string text)
        {
            return new string(text.Reverse().ToArray());
        }
    }
}
