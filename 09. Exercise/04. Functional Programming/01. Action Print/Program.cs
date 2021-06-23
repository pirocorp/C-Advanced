namespace _01._Action_Print
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var stringsList = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = Console.WriteLine;

            foreach (var str in stringsList)
            {
                print(str);
            }
        }
    }
}
