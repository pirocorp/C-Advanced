namespace _38._Movie_Time
{
    using System;

    public class Movie
    {
        public Movie(string name, string genre, Duration duration)
        {
            Name = name;
            Genre = genre;
            Duration = duration;
        }

        public string Name { get; private set ; }
        public string Genre { get; private set ; }
        public Duration Duration { get; private set ; }

        public static Movie ParseMovie(string input)
        {
            var tokens = input.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var currentName = tokens[0];
            var currentGenre = tokens[1];
            var currentDuration = _Movie_Time.Duration.ParseDuration(tokens[2]);

            return new Movie(currentName, currentGenre, currentDuration);
        }
    }
}
