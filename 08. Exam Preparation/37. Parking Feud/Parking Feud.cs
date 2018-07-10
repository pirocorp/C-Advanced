using System.Linq;

namespace _37._Parking_Feud
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var tokens = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var parkingSpotRows = tokens[0];
            var parkingSpotCols = tokens[1];

            var parkingSpotSamEntrance = int.Parse(Console.ReadLine());

            var samIsParkedSuccessfully = false;
            bool conflict;

            while (!samIsParkedSuccessfully)
            {
                var parkingSpotForEachEntrance = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                if (parkingSpotForEachEntrance.Length != parkingSpotForEachEntrance.Distinct().ToArray().Length)
                {
                    conflict = true;
                }
                else
                {
                    conflict = false;
                }


            }
        }
    }
}
