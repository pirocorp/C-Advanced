namespace _05._Filter_By_Age
{
    using System;
    using System.Collections.Generic;


    public class FilterByAge
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var peoples = ReadPeopleFromConsole(n);

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> ageFilter = CreateAgeFilterMethod(condition, age);
            Action<KeyValuePair<string, int>> printPerson = CreatePrintPersonMethod(format);

            PrintFilteredStudent(peoples, ageFilter, printPerson);
        }

        private static void PrintFilteredStudent(Dictionary<string, int> peoples, Func<int, bool> ageFilter, Action<KeyValuePair<string, int>> printPerson)
        {
            foreach (var people in peoples)
            {
                if (ageFilter(people.Value))
                {
                    printPerson(people);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrintPersonMethod(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default:
                    return null;
            } 
        }

        private static Func<int, bool> CreateAgeFilterMethod(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;
            } 
        }

        private static Dictionary<string, int> ReadPeopleFromConsole(int n)
        {
            var peoples = new Dictionary<string, int>(n);

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                peoples[name] = age;
            }

            return peoples;
        }
    }
}
