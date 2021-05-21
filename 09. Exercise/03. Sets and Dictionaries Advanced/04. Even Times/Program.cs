namespace _04._Even_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var collection = new Dictionary<int, int>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());

                if (!collection.ContainsKey(input))
                {
                    collection[input] = 0;
                }

                collection[input]++;
            }

            var result = collection.First(x => x.Value % 2 == 0).Key;
            Console.WriteLine(result);
        }
    }
}
