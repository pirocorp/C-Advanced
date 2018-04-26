namespace _01._Action_Print
{
    using System;

    public class ActionPrint
    {
        public static void Main()
        {
            var stringsList = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = x => Console.WriteLine(x);

            foreach (var str in stringsList)
            {
                print(str);
            }
        }
    }
}
