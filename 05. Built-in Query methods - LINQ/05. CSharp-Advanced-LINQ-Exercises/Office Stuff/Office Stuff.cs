namespace Office_Stuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main()
        {
            var companies = ReadCompaniesDataFromConsole()
                .OrderBy(x => x.Key);

            foreach (var company in companies)
            {
                var products = company.Value
                    .Select(x => $"{x.Key}-{x.Value}")
                    .ToArray();

                Console.WriteLine($"{company.Key}: {string.Join(", ", products)}");
            }
        }

        private static Dictionary<string, Dictionary<string, int>> ReadCompaniesDataFromConsole()
        {
            var companies = new Dictionary<string, Dictionary<string, int>>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new[] {"|", "-"}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var company = tokens[0];
                var amount = int.Parse(tokens[1]);
                var product = tokens[2];

                if (!companies.ContainsKey(company))
                {
                    companies[company] = new Dictionary<string, int>();
                }

                if (!companies[company].ContainsKey(product))
                {
                    companies[company][product] = 0;
                }

                companies[company][product] += amount;
            }

            return companies;
        }
    }
}
