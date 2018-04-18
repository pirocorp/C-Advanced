namespace _0.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Examples
    {
        public static void Main()
        {
            StackExamples(); // LIFO
            QueueExamples(); // FIFO
        }

        private static void QueueExamples()
        {
            var texts = new Queue<string>();

            texts.Enqueue("First");
            texts.Enqueue("Second");
            texts.Enqueue("Third");

            Console.WriteLine($"Count: {texts.Count}");

            var currentText = texts.Peek();

            Console.WriteLine($"Peek: {currentText}");

            var firstElement = texts.Dequeue();

            Console.WriteLine($"First element of queue: {firstElement}");
            
            firstElement = texts.Dequeue();

            Console.WriteLine($"First element of queue: {firstElement}");

            texts.Enqueue("Last One");

            Console.WriteLine($"[{string.Join(", ", texts.Select(x => x.ToString()))}]");

            texts.Clear();

            Console.WriteLine($"Count: {texts.Count}");
        }

        private static void StackExamples()
        {
            var stackExample = new Stack<int>();

            stackExample.Push(5);
            stackExample.Push(10);
            stackExample.Push(2);
            stackExample.Push(100);

            foreach (var item in stackExample)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var currentNumber = stackExample.Peek();

            Console.WriteLine($"Peek: {currentNumber}");

            var lastNumber = stackExample.Pop();

            Console.WriteLine($"Pop {lastNumber}");

            currentNumber = stackExample.Peek();

            Console.WriteLine($"Peek: {currentNumber}");

            Console.WriteLine($"Count: {stackExample.Count}");

            var arrFromStack = stackExample.ToArray();

            Console.WriteLine($"[{string.Join(", ", arrFromStack.Select(x => x.ToString()))}]");

            stackExample.Clear();

            Console.WriteLine($"Count: {stackExample.Count}");
            Console.WriteLine();
        }
    }
}
