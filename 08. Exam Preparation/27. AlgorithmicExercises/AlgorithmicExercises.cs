using System;
using System.Text;

namespace _27._AlgorithmicExercises
{
    public class AlgorithmicExercises
    {
        public static void Main()
        {
            //ReverseWordsInString();
            CountConsecutiveDigits();
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
