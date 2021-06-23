namespace _01._Scheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var tasks = new Stack<int>(ReadIntCollectionFromConsole(", "));

            var threads = new Queue<int>(ReadIntCollectionFromConsole(" "));

            var taskToKill = int.Parse(Console.ReadLine());

            var task = tasks.Pop();

            while (task != taskToKill && tasks.Count > 0)
            {
                var thread = threads.Dequeue();

                if (thread >= task)
                {
                    task = tasks.Pop();
                }
            }

            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threads));
        }

        private static IEnumerable<int> ReadIntCollectionFromConsole(string separator)
            => Console.ReadLine()
                .Split(separator)
                .Select(int.Parse)
                .ToArray();
    }
}
