namespace _02._Date_Modifier
{
    using System;

    public class Program
    {
        static void Main()
        {
            var x = new DateModifier(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine(x.DaysBetweenDates());
        }
    }
}
