namespace _07._Car_Salesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class CarSalesman
    {
        public static void Main()
        {
            var engines = new Dictionary<string, Engine>();
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                var engineModel = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).First();
                var currentEngine = Engine.Parse(inputLine);

                engines.Add(engineModel, currentEngine);
            }

            n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var engineModel = tokens[1];
                var currentEngine = engines[engineModel];
                var currentCar = Car.Parse(inputLine, currentEngine);

                cars.Add(currentCar);
            }

            cars.ForEach(x => Console.Write(x));
        }
    }
}
