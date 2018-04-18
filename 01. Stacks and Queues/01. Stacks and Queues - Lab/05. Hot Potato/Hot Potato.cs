namespace _05.Hot_Potato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var childrens = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var number = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(childrens);

            while (queue.Count > 1)
            {
                for (var i = 1; i < number; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
