namespace _07._Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<int[]>();

            for (var i = 0; i < n; i++)
            {
                var pump = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(pump);
            }

            for (var currentStart = 0; currentStart < n; currentStart++)
            {
                var fuel = 0;
                var fullCircle = true;

                for (var distance = 0; distance < n; distance++)
                {
                    var currentPump = queue.Dequeue();
                    queue.Enqueue(currentPump);

                    var pumpFuel = currentPump[0];
                    var nextPumpDistance = currentPump[1];

                    fuel += pumpFuel - nextPumpDistance;

                    if (fuel < 0)
                    {
                        currentStart += distance;
                        fullCircle = false;
                        break;
                    }
                }

                if (fullCircle)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }
        }
    }
}
