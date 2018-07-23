namespace _38._Movie_Time
{
    using System;

    public class Duration
    {
        public Duration(long hours = 0, long minutes = 0, long seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public long Hours { get; private set; }
        public long Minutes { get; private set; }
        public long Seconds { get; private set; }
        public long TotalDurationInSeconds => (Hours * 60 + Minutes) * 60 + Seconds;

        public void AddDuration(long hours, long minutes, long seconds)
        {
            var minToAdd = (Seconds + seconds) / 60;
            Seconds = (Seconds + seconds) % 60;

            var hoursToAdd = (Minutes + minutes + minToAdd) / 60;
            Minutes = (Minutes + minutes + minToAdd) % 60;

            Hours += hoursToAdd + hours;
        }

        public static Duration ParseDuration(string input)
        {
            var tokens = input.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            var currentHourse = long.Parse(tokens[0]);
            var currentMinutes = long.Parse(tokens[1]);
            var currentSeconds = long.Parse(tokens[2]);

            return new Duration(currentHourse, currentMinutes, currentSeconds);
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }
    }
}
