namespace _38._Movie_Time
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieTime
    {
        public static void Main()
        {
            var favoriteMovieGenre = Console.ReadLine();
            var favoriteDuration = Console.ReadLine().ToLower();

            var movieList = new List<Movie>();

            var inputLine = Console.ReadLine();

            while (inputLine != "POPCORN!")
            {
                var currentMovie = Movie.ParseMovie(inputLine);
                movieList.Add(currentMovie);
                inputLine = Console.ReadLine();
            }

            var moviesToOffer = movieList
                .Where(m => m.Genre== favoriteMovieGenre)
                .ToList();

            if (favoriteDuration == "long")
            {
                moviesToOffer = moviesToOffer
                    .OrderByDescending(m => m.Duration.TotalDurationInSeconds)
                    .ThenBy(m => m.Name)
                    .ToList();
            }
            else
            {
                moviesToOffer = moviesToOffer
                    .OrderBy(m => m.Duration.TotalDurationInSeconds)
                    .ThenBy(m => m.Name)
                    .ToList();
            }

            inputLine = Console.ReadLine();
            var index = 0;

            while (inputLine != "Yes")
            {
                Console.WriteLine(moviesToOffer[index++].Name);
                inputLine = Console.ReadLine();
            }

            Console.WriteLine(moviesToOffer[index].Name);
            Console.WriteLine($"We're watching {moviesToOffer[index].Name} - {moviesToOffer[index].Duration}");
            var totalPlayListTime = new Duration();
            totalPlayListTime.AddDuration(0, 0, movieList.Sum(m => m.Duration.TotalDurationInSeconds));
            Console.WriteLine($"Total Playlist Duration: {totalPlayListTime}");
        }
    }
}
