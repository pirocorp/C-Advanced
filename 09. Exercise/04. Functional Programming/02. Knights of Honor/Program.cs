namespace _02._Knights_of_Honor
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            void PrintName(string s) => Console.WriteLine($"Sir {s}");

            Console.ReadLine()
                .Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(PrintName);
        }
    }
}
