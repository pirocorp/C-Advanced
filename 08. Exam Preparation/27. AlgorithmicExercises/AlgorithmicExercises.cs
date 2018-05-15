using System;
using System.Collections.Generic;
using System.Text;

namespace _27._AlgorithmicExercises
{
    public class AlgorithmicExercises
    {
        public static void Main()
        {
            //ReverseWordsInString();
            //CountConsecutiveDigits();
            //Calculator();
            //ConvertStringtoInteger();
        }

        private static void ConvertStringtoInteger()
        {
            var inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine($"FormatException");
                return;
            }

            var rezult = 0;
            var multiplayer = 1;

            for (var i = inputString.Length - 1; i >= 0; i--)
            {
                var currentItem = inputString[i];

                try
                {
                    checked
                    {
                        rezult += multiplayer * ParseDigit(currentItem);
                        multiplayer *= 10;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"OverflowException");
                    return;
                }
            }

            Console.WriteLine(rezult);
        }

        private static int ParseDigit(char currentItem)
        {
            switch (currentItem)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case '0':
                    return 0;
                default:
                    return 0;
            }
        }

        private static void Calculator()
        {
            var tokens = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);

            var expression = new Stack<string>();

            for (var i = 0; i < tokens.Length; i++)
            {
                var currentElement = tokens[i];

                if (currentElement.Contains("*") || currentElement.Contains("/"))
                {
                    if (currentElement.Contains("*"))
                    {
                        var result = decimal.Parse(expression.Pop()) * decimal.Parse(tokens[i + 1]);
                        expression.Push($"{result}");
                        i++;
                    }
                    else
                    {
                        var result = decimal.Parse(expression.Pop()) / decimal.Parse(tokens[i + 1]);
                        expression.Push($"{result}");
                        i++;
                    }
                }
                else
                {
                    expression.Push(currentElement);
                }
            }

            while (expression.Count > 1)
            {
                var secondElement = decimal.Parse(expression.Pop());
                var operand = expression.Pop();
                var firstElement = decimal.Parse(expression.Pop());

                if (operand == "+")
                {
                    var result = firstElement + secondElement;
                    expression.Push(result.ToString());
                }
                else
                {
                    var result = firstElement - secondElement;
                    expression.Push(result.ToString());
                }
            }

            Console.WriteLine(expression.Pop());
        }

        private static void CountConsecutiveDigits()
        {
            var result = new StringBuilder();

            var inputLine = Console.ReadLine();
            var count = 1;

            var previusChar = inputLine[0];

            for (var index = 1; index < inputLine.Length; index++)
            {
                var currentChar = inputLine[index];

                if (currentChar == previusChar)
                {
                    count++;
                }
                else
                {
                    result.Append(count.ToString());
                    result.Append(previusChar);
                    count = 1;
                    previusChar = currentChar;
                }
            }

            if (count > 0)
            {
                var lastChar = inputLine[inputLine.Length - 1];
                result.Append(count);
                result.Append(lastChar);
            }

            Console.WriteLine(result);
        }

        private static void ReverseWordsInString()
        {
            var inputString = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var result = new string[inputString.Length];

            var first = new string(char.ToUpper(inputString[inputString.Length - 1][0]), 1);
            first += inputString[inputString.Length - 1].Substring(1);

            var index = 0;
            result[index++] = first;

            for (var i = inputString.Length - 2; i > 0; i--)
            {
                result[index++] = inputString[i];
            }

            var last = new string(char.ToLower(inputString[0][0]), 1);
            last += inputString[0].Substring(1);

            result[index++] = last;

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
