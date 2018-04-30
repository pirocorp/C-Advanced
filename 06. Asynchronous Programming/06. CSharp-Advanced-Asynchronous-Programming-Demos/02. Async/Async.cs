namespace _02.Async
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class Async
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var task = new Task(() => PrintNumbersInRange(n));
            task.Start();
            Console.WriteLine("Main thread is done");
            task.Wait();
        }

        private static void PrintNumbersInRange(int bound)
        {
            for (var i = 0; i <= bound; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Thread {0} is done", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
