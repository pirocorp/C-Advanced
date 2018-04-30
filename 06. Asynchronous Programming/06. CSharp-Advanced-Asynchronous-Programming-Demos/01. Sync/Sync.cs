namespace _01.Sync
{
    using System;

    public class Sync
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            PrintNumbersInRange(n);
            Console.WriteLine("Main thread is done");
        }

        private static void PrintNumbersInRange(int bound)
        {
            for (var i = 0; i <= bound; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
