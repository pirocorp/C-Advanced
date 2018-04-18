namespace _06.Traffic_Jam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TrafficJam
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();

            var count = 0;
            var command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "green")
                {
                    var carsPassed = Math.Min(n, queue.Count);

                    for (var i = 0; i < carsPassed; i++)
                    {
                        var currentCar = queue.Dequeue();
                        Console.WriteLine($"{currentCar} passed!");
                        count++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
