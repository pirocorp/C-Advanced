namespace _13._TriFunction
{
    using System;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            Func<string, int, bool> isNameSearched = (name, sum) => name.Sum(c => (int)c) >= sum;

            var x = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var nameResult = names.FirstOrDefault(n => NameFound(n, x));
            //var nameResult = names.FirstOrDefault(n => isNameSearched(n, x));

            Console.WriteLine(nameResult);
        }

        public static bool NameFound(string name, int sum)
        {
            var sumName = name.Sum(c => (int) c);

            return sumName >= sum;
        }
    }   
}
