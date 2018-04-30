namespace _05.NoThreadSafety
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NoThreadSafety
    {
        static List<int> numbers;

        static void Main(string[] args)
        {
            numbers = Enumerable.Range(0, 10000).ToList();

            var tasks = new List<Task>();

            for (var i = 0; i < 4; i++)
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

        public static void RemoveAllElements()
        {
            while (numbers.Count > 0)
            {
                var lastIndex = numbers.Count - 1;
                numbers.RemoveAt(lastIndex);
            }
        }
    }
}
