namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    public class AddVat
    {
        public static void Main()
        {
            Func<decimal, decimal> vat = x => x * 1.2m;
            Action<decimal> printer = x => Console.WriteLine($"{x:F2}");

            var prices = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(vat)
                .ToArray();

            foreach (var price in prices)
            {
                printer(price);
            }
        }
    }
}
