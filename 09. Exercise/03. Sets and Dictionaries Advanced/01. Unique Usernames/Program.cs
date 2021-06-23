namespace _01._Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            var names = new HashSet<string>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                names.Add(input);
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
