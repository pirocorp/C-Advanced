namespace ManagedThreads
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class PrimesThread
    {
        public static void Main()
        {
            Console.WriteLine("Enter range first:");
            var rangeFirst = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter range last:");
            var rangeLast = int.Parse(Console.ReadLine());

            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            var primes = new List<int>();

            var task  = Task.Factory.StartNew(() =>
            {
                var finished = false;

                while (true)
                {
                    finished = PrintPrimesInRange(rangeFirst, rangeLast, out primes);

                    if (finished || token.IsCancellationRequested)
                    {
                        Console.WriteLine(string.Join(", ", primes));
                        break;
                    }
                }
            }, token);
            
            Console.WriteLine("What should I do?");
            var command = Console.ReadLine();

            while (true)
            {
                if (command == "stop")
                {
                    tokenSource.Cancel();
                    Console.WriteLine("Process canceled");
                    Console.WriteLine(string.Join(", ", primes.ToArray()));
                    break;

                }
                else if (command == "exit")
                {
                    break;
                }

                command = Console.ReadLine();
            }
        }

        public static bool PrintPrimesInRange(int rangeFirst, int rangeLast, out List<int> primes)
        {
            primes = new List<int>();

            for (var number = rangeFirst; number < rangeLast; number++)
            {
                var isPrime = true;

                for (var divider = 2; divider < number; divider++)
                {
                    if (number % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(number);
                }              
            }

            Console.WriteLine(string.Join(", ", primes));
            return true;
        }
    }
}
