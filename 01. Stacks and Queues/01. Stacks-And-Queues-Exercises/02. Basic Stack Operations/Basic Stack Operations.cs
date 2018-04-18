using System.Runtime.InteropServices;

namespace _02.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BasicStackOperations
    {
        public static void Main(string[] args)
        {
            var tokes = ReadIntegerArrayFromConsole();

            var numberOfElementsToPushOnStack = tokes[0];
            var numberOfElementsToPopFromStack = tokes[1];
            var elementX = tokes[2];

            var stackElements = ReadIntegerArrayFromConsole();
            var stackInt = ProcessStackElements(stackElements, numberOfElementsToPushOnStack, numberOfElementsToPopFromStack);

            if (stackInt.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stackInt.Contains(elementX))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stackInt.Min());
            }
        }

        private static Stack<int> ProcessStackElements(int[] stackElements, int numberOfElementsToPushOnStack, int numberOfElementsToPopFromStack)
        {
            if (numberOfElementsToPopFromStack >= numberOfElementsToPushOnStack)
            {
                return new Stack<int>();
            } 

            var result = new Stack<int>();

            for (var i = 0; i < numberOfElementsToPushOnStack; i++)
            {
                result.Push(stackElements[i]);
            }

            for (var i = 0; i < numberOfElementsToPopFromStack; i++)
            {
                result.Pop();
            }

            return result;
        }

        private static int[] ReadIntegerArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
