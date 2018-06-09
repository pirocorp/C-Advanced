namespace _36._Crossroads
{
    using System;
    using System.Collections.Generic;

    public class Crossroads
    {
        private static int carsPassedCount = 0;
        private static Queue<string> cars = new Queue<string>();
        private static int DurationInSeconds = 0;
        private static int FreeWindow = 0;

        public static void Main()
        {
            DurationInSeconds = int.Parse(Console.ReadLine());
            FreeWindow = int.Parse(Console.ReadLine());

            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                if (inputLine == "green")
                {
                    if (!ProcessCars())
                    {
                        return;
                    }
                }

                cars.Enqueue(inputLine);
                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carsPassedCount} total cars passed the crossroads.");
        }

        private static bool ProcessCars()
        {
            var currentGreenLight = DurationInSeconds;
            var currentFreeWindow = FreeWindow;
            var currentCar = string.Empty;

            while (currentGreenLight > 0 && cars.Count > 0)
            {
                currentCar = cars.Dequeue();
                currentGreenLight -= currentCar.Length;
                carsPassedCount++;
            }

            if (currentGreenLight >= 0)
            {
                return true;
            }

            var partsOfCarStillInCrossroad = Math.Abs(currentGreenLight);

            if (partsOfCarStillInCrossroad > currentFreeWindow)
            {
                var indexOfHit = currentCar.Length - partsOfCarStillInCrossroad;
                indexOfHit += currentFreeWindow;
                
                Console.WriteLine($"A crash happened!");
                Console.WriteLine($"{currentCar} was hit at {currentCar[indexOfHit]}.");

                return false;
            }

            return true;
        }
    }
}
