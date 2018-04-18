namespace _03.Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            var decimalNumber = int.Parse(Console.ReadLine());
            var binDigits = new Stack<byte>();

            if (decimalNumber == 0)
            {
                binDigits.Push(0);
            }

            while (decimalNumber != 0)
            {
                binDigits.Push((byte)(decimalNumber % 2));
                decimalNumber /= 2;
            }

            Console.WriteLine(string.Join("", binDigits));
        }
    }
}
