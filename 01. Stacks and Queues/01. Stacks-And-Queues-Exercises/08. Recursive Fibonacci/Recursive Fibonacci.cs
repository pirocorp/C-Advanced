using System.Collections.Generic;

namespace _08.Recursive_Fibonacci
{
    using System;


    public class RecursiveFibonacci
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var fibo = GetFibonaci(n);

            Console.WriteLine(fibo);
        }

        //Recursive fibonachi optimized with memoization
        private static long GetFibonaci(int n, List<long> lookupTable = null)
        { 
            if (lookupTable == null)
            {
                lookupTable = new List<long>();
                lookupTable.Add(1);
                lookupTable.Add(1);
            }

            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 1;
            }

            if (n <= 0)
            {
                return 0;
            }

            if (lookupTable.Count >= n)
            {
                return lookupTable[n-1];
            }

            var currentFibo = GetFibonaci(n - 1, lookupTable) + GetFibonaci(n - 2, lookupTable);
            lookupTable.Add(currentFibo);

            return currentFibo;
        }   
    }
}