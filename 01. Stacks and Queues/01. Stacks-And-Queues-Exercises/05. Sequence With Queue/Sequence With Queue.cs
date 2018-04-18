namespace _05.Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var queueGenerated = new Queue<long>();
            var queueFinal = new Queue<long>();

            var elementX = n;
            queueGenerated.Enqueue(elementX);

            while (queueGenerated.Count < 50)
            {
                var generatedElementG1 = elementX + 1;
                var generatedElementG2 = 2 * elementX + 1;
                var generatedElementG3 = elementX + 2;

                queueGenerated.Enqueue(generatedElementG1);
                queueGenerated.Enqueue(generatedElementG2);
                queueGenerated.Enqueue(generatedElementG3);

                queueFinal.Enqueue(queueGenerated.Dequeue());
                elementX = queueGenerated.Peek();
            }

            //Console.WriteLine($"Generated Count: {queueGenerated.Count}");
            //Console.WriteLine($"Final Count: {queueFinal.Count}");

            for (var i = queueFinal.Count; i < 50; i++)
            {
                queueFinal.Enqueue(queueGenerated.Dequeue());
            }
            
            Console.WriteLine(string.Join(" ", queueFinal));
        }
    }
}