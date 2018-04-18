namespace _04.Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            var tokens = ReadIntegerArrayFromConsole();

            var addCount = tokens[0];
            var removeCount = tokens[1];
            var elementX = tokens[2];

            var queueElements = ReadIntegerArrayFromConsole();

            if (addCount <= removeCount)
            {
                Console.WriteLine(0);
                return;
            }

            var queue = new Queue<int>();

            for (var i = 0; i < addCount; i++)
            {
                queue.Enqueue(queueElements[i]);
            }

            for (var i = 0; i < removeCount; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementX))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }

        private static int[] ReadIntegerArrayFromConsole()
        {
            return Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
