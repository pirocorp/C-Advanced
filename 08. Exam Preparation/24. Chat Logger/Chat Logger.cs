namespace _24._Chat_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security;

    public class ChatLogger
    {
        public static void Main()
        {
            var dateTimeFormat = "dd-MM-yyyy HH:mm:ss";
            var currentDateTime = DateTime.ParseExact(Console.ReadLine(), dateTimeFormat, CultureInfo.InvariantCulture);

            var messages = new Dictionary<string, DateTime>();
             
            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                var tokens = inputLine
                    .Split(new[] { " / " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var dateTimeAsString = tokens[1].Trim();
                var dateTime = DateTime.ParseExact(dateTimeAsString, dateTimeFormat, CultureInfo.InvariantCulture);
                var message = tokens[0];
                messages[message] = dateTime;

                inputLine = Console.ReadLine();
            }


            messages = messages
                .OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            var lastElement = messages.Skip(messages.Count - 1).Single();
            var dateTimeOfLastElement = lastElement.Value;
            var timeSpan = currentDateTime.Subtract(dateTimeOfLastElement);
            var notificationAfterLastMessage = GenerateNotification(timeSpan, dateTimeOfLastElement, currentDateTime);

            foreach (var message in messages)
            {
                Console.WriteLine($"<div>{SecurityElement.Escape(message.Key)}</div>");
            }

            Console.WriteLine($"<p>Last active: <time>{notificationAfterLastMessage}</time></p>");
        }

        private static string GenerateNotification(TimeSpan timeSpan, DateTime dateTimeOfLastElement, DateTime currentDateTime)
        {
            var minutes = timeSpan.TotalMinutes;
            var hours = timeSpan.TotalHours;
            var days = timeSpan.Days;

            var isToday = IsDateCurrentDate(dateTimeOfLastElement, currentDateTime);
            var isYesterday = IsDateYesterday(dateTimeOfLastElement, currentDateTime);

            if (minutes < 1 && isToday)
            {
                return "a few moments ago";
            }

            if (hours < 1 && isToday)
            {
                var fullMinutes = Math.Floor(minutes);
                var minString = "minute(s)";//fullMinutes > 1 ? "minutes" : "minute";
                return $"{fullMinutes} {minString} ago";
            }

            if (hours < 24 && isToday)
            {
                var fullHours = Math.Floor(hours);
                var hoursString = "hour(s)";//fullHours > 1 ? "hours" : "hour";
                return $"{fullHours} {hoursString} ago";
            }

            if (isYesterday)
            {
                return "yesterday";
            }

            return $"{dateTimeOfLastElement.Day:D2}-{dateTimeOfLastElement.Month:D2}-{dateTimeOfLastElement.Year:D2}";
        }

        private static bool IsDateYesterday(DateTime dateTimeOfLastElement, DateTime currentDateTime)
        {
            var lastElementDay = dateTimeOfLastElement.Day;
            var lastElementMont = dateTimeOfLastElement.Month;
            var lastElementYear = dateTimeOfLastElement.Year;

            var currentDateDay = currentDateTime.Day;
            var currentDateMonth = currentDateTime.Month;
            var currentDateYear = currentDateTime.Year;

            if (lastElementDay + 1 == currentDateDay && lastElementMont == currentDateMonth &&
                lastElementYear == currentDateYear)
            {
                return true;
            }

            return false;
        }
       
        private static bool IsDateCurrentDate(DateTime dateTimeOfLastElement, DateTime currentDateTime)
        {
            var lastElementDay = dateTimeOfLastElement.Day;
            var lastElementMont = dateTimeOfLastElement.Month;
            var lastElementYear = dateTimeOfLastElement.Year;

            var currentDateDay = currentDateTime.Day;
            var currentDateMonth = currentDateTime.Month;
            var currentDateYear = currentDateTime.Year;

            if (lastElementDay == currentDateDay && lastElementMont == currentDateMonth &&
                lastElementYear == currentDateYear)
            {
                return true;
            }

            return false;
        }
    }
}
