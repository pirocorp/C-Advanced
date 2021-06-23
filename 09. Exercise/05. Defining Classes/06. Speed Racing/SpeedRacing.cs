namespace _04._Speed_Racing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SpeedRacing
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (var i = 0; i < n; i++)
            {
                cars.Add(Car.Parse(Console.ReadLine()));
            }

            var inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var model = tokens[1];
                var amountOfKm = double.Parse(tokens[2]);

                var currentCar = cars.Where(x => x.Model == model).First();

                if (!currentCar.Drive(amountOfKm))
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
            }

            cars.ForEach(x => Console.WriteLine($"{x.Model} {x.FuelAmount:F2} {x.DistanceTraveled}"));
        }
    }
}
