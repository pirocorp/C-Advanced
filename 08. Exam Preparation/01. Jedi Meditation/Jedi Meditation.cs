namespace _01._Jedi_Meditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JediMeditation
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var allJedi = new List<string>();

            for (var i = 0; i < n; i++)
            {
                var jedis = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                allJedi.AddRange(jedis);
            }

            Collect();

            var isYodaPresent = allJedi.Any(x => x.Contains("y"));

            if (isYodaPresent)
            {
                Collect();
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('m'))));
                Console.Write(" ");
                Collect();
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('k'))));
                Console.Write(" ");
                Collect();
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('t') || x.Contains('s'))));
                Console.Write(" ");
                Collect();
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('p'))));
                Collect();
                Console.WriteLine();
            }
            else
            {
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('t') || x.Contains('s'))));
                Console.Write(" ");
                Collect();
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('m'))));
                Console.Write(" ");
                Collect();
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('k'))));
                Console.Write(" ");
                Collect();
                Console.Write(string.Join(" ", allJedi.Where(x => x.Contains('p'))));
                Console.WriteLine();
                Collect();
            }
        }

        static void Collect()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }
    }
}