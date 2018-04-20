using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Group_Numbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lenght = numbers.Length;

            var zero = new List<int>(lenght);
            var one = new List<int>(lenght);
            var two = new List<int>(lenght);

            for (var i = 0; i < numbers.Length; i++)
            {
                if (Math.Abs(numbers[i]) % 3 == 0)
                {
                    zero.Add(numbers[i]);
                }
                else if (Math.Abs(numbers[i]) % 3 == 1)
                {
                    one.Add(numbers[i]);
                }
                else
                {
                    two.Add(numbers[i]);
                }
            }

            for (var i = 0; i < zero.Count; i++)
            {
                Console.Write(zero[i] + " ");
            }

            Console.WriteLine();

            for (var i = 0; i < one.Count; i++)
            {
                Console.Write(one[i] + " ");
            }

            Console.WriteLine();

            for (var i = 0; i < two.Count; i++)
            {
                Console.Write(two[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
