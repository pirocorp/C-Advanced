namespace _05._Raw_Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RawData
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (var i = 0; i < n; i++)
            {
                cars.Add(Car.Parse(Console.ReadLine()));
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                cars
                    .Where(x => x.CargoProp.CargoType == "fragile")
                    .Where(x => x.Tires.Any(t => t.Pressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.Model}"));
            }
            else if(command == "flamable")
            {
                cars
                    .Where(x => x.CargoProp.CargoType == "flamable")
                    .Where(x => x.EngineProp.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.Model}"));
            }
        }
    }
}
