namespace Little_John
{
    using System;
    using System.Linq;

    public class LittleJohn
    {
        public static void Main(string[] args)
        {
            var inputString = string.Empty;

            var large = 0;
            var medium = 0;
            var small = 0;

            for (var i = 0; i < 4; i++)
            {
                inputString = Console.ReadLine();

                var counters = CountStringOccurrences(inputString);

                small += counters[0];
                medium += counters[1];
                large += counters[2];
            }

            var decString = int.Parse($"{small}{medium}{large}");
            var binString = Convert.ToString(decString, 2);
            var reversedBin = binString.Reverse();
            var concatBin = binString + new string(reversedBin.ToArray());
            var result = Convert.ToInt32(concatBin, 2);

            Console.WriteLine(result);
        }

        public static int[] CountStringOccurrences(string inputString)
        {
            var typeOfArrows = new[] { ">----->", ">>----->", ">>>----->>" };

            var maxArrow = ">>>----->>";
            var medArrow = ">>----->";
            var minArrow = ">----->";

            var maxCount = 0;
            var medCount = 0;
            var minCount = 0;

            var i = 0;

            while (i != -1)
            {
                if (inputString.IndexOf(maxArrow, i) != -1)
                {
                    i += maxArrow.Length;
                    maxCount++;
                }
                else if (inputString.IndexOf(medArrow, i) != -1)
                {
                    i += medArrow.Length;
                    medCount++;
                }
                else if (inputString.IndexOf(minArrow, i) != -1)
                {
                    i += minArrow.Length;
                    minCount++;
                }
                else
                {
                    i = -1;
                }
            }

            return new []{minCount, medCount, maxCount};
        }
    }
}
