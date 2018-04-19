namespace _09.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StackFibonacci
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var fibo = GetFibo(n);

            Console.WriteLine(fibo);
        }

        private static long GetFibo(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (n == 0)
            {
                return 0;
            }

            var fiboStack = new Stack<long>();

            fiboStack.Push(1);
            fiboStack.Push(1);

            while (fiboStack.Count < n)
            {
                var previousFibo = fiboStack.Pop();
                var beforePreviousFibo = fiboStack.Peek();
                var currentFibo = previousFibo + beforePreviousFibo;

                fiboStack.Push(previousFibo);
                fiboStack.Push(currentFibo);
            }

            return fiboStack.Peek();
        }
    }
}
