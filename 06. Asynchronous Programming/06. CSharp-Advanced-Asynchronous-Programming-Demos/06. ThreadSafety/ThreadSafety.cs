namespace _06.ThreadSafety
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ThreadSafety
    {
        private static List<int> numbers;

        public static void Main(string[] args)
        {
            numbers = Enumerable.Range(0, 1000000).ToList();

            var tasks = new List<Task>();

            for (var i = 0; i < Environment.ProcessorCount; i++)
            {
                var task = new Task(() => RemoveAllElements());

                tasks.Add(task);
                task.Start();
            }

            foreach (var thread in tasks)
            {
                try
                {
                    thread.Wait();
                }
                catch (AggregateException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }

        static void RemoveAllElements()
        {
            var currentId = Thread.CurrentThread.ManagedThreadId;

            while (numbers.Count > 0)
            {
                lock (numbers)
                {
                    var lastIndex = numbers.Count - 1;

                    if (lastIndex < 0)
                    {
                        break;
                    }

                    var taskIdOffset = currentId % Environment.ProcessorCount;
                    var taskId = taskIdOffset + 1;
                    var numberGrabbed = numbers[lastIndex];

                    Console.CursorLeft = 0;
                    Console.CursorTop = taskId;
                    Console.WriteLine($"{taskId} grabbed {numberGrabbed:D7} and went");
                    numbers.RemoveAt(lastIndex);
                }
            }

            Console.CursorLeft = 0;
            Console.CursorTop = 5;
        }
    }
}
