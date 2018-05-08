using System.Globalization;
using System.Linq;

namespace _23._PIN_Validation
{
    using System;

    public class PinValidation
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var gender = Console.ReadLine();
            var pin = Console.ReadLine();


            var nameIsCorrect = ValidateName(name);
            var pinLenghtIsCorrect = pin.Length == 10;
            var dateIsCorrect = CheckIfDateIsCorrect(pin);
            var genderIsCorrect = CheckIfGenderIsCorrect(pin, gender);
            var checkSumIsCorrect = CheckIfCheckSumIsCorrect(pin);

            if (nameIsCorrect && pinLenghtIsCorrect && dateIsCorrect && genderIsCorrect && checkSumIsCorrect)
            {
                Console.WriteLine($"{{\"name\":\"{name}\",\"gender\":\"{gender}\",\"pin\":\"{pin}\"}}");
            }
            else
            {
                Console.WriteLine($"<h2>Incorrect data</h2>");
            }
        }

        private static bool ValidateName(string name)
        {
            var tokens = name.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            var count = tokens.Length == 2;
            var upperCase = tokens.All(x => char.IsUpper(x[0]));

            return count && upperCase;
        }

        private static bool CheckIfCheckSumIsCorrect(string pin)
        {
            var checkSum = int.Parse(pin.Last().ToString());

            var digits = pin
                .Take(9)
                .Select(x => int.Parse(x.ToString()))
                .ToArray();

            var multiplayers = new [] {2, 4, 8, 5, 10, 9, 7, 3, 6};

            var sum = 0;

            for (var i = 0; i < 9; i++)
            {
                sum += digits[i] * multiplayers[i];
            }

            var calculatedCheckSum = sum % 11;

            if (calculatedCheckSum == 10)
            {
                calculatedCheckSum = 0;
            }

            return calculatedCheckSum == checkSum;
        }

        private static bool CheckIfGenderIsCorrect(string pin, string gender)
        {
            var genderCheckSum = int.Parse(new string(pin.Skip(8).Take(1).ToArray()));

            if (gender == "male")
            {
                if (genderCheckSum % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (gender == "female")
            {
                if (genderCheckSum % 2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIfDateIsCorrect(string pin)
        {
            var yearString = new string(pin.Take(2).ToArray());
            var month = int.Parse(new string(pin.Skip(2).Take(2).ToArray()));
            var day = int.Parse(new string(pin.Skip(4).Take(2).ToArray()));

            if (month >= 1 && month <= 12)
            {
                month -= 0;
                yearString = "19" + yearString;
            }
            else if (month >= 21 && month <= 32)
            {
                month -= 20;
                yearString = "18" + yearString;
            }
            else if (month >= 41 && month <= 52)
            {
                month -= 40;
                yearString = "20" + yearString;
            }
            else
            {
                return false;
            }

            var year = int.Parse(yearString);
            var date = $"{year}-{month:D2}-{day:D2}";
            var format = "yyyy-MM-dd";

            return DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt);
        }
    }
}
