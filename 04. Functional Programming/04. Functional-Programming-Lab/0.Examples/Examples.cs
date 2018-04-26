namespace _0.Examples
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using MyExtensions;

    public class Examples
    {
        delegate double MathAction(double num);
        public delegate TResult MyFunction<in T, out TResult>(T arg); //This is FUNC    

        public static void Main()
        {
            //SortEvenNumbers();
            //Play();
            //DeferredExecution();
        }

        private static void DeferredExecution()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var query = list.Where(n => n > 2);

            Console.WriteLine($"{string.Join(", ", query)}");

            list.Add(6);
            list.Add(7);
            list.Add(8);

            Console.WriteLine($"{string.Join(", ", query)}");

        }

        private static void Play()
        {
            Func<string, int> test = x => int.Parse(x);
            MyFunction<string, int> myTest = x => int.Parse(x);
        }

        private static void SortEvenNumbers()
        {
            var numbers = Console.ReadLine()
                .Split(new [] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ForEach(Console.WriteLine)
                .ToArray();

            var result = string.Join(", ", numbers);

            Console.WriteLine(result);
        }
    }
}
