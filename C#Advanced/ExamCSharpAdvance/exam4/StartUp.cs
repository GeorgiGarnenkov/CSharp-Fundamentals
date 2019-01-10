using System;
using System.Collections.Generic;
using System.Linq;

namespace exam4
{
    public class StartUp
    {

        public static void Main()
        {
            var favoriteGenre = Console.ReadLine();

            var movieDuration = Console.ReadLine();

            List<Movie> movies = new List<Movie>();
            List<TimeSpan> moviesDuration = new List<TimeSpan>();
            string input;

            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                var commandArgs = input.Split('|');
                var name = commandArgs[0];
                var genre = commandArgs[1];
                var duration = TimeSpan.Parse(commandArgs[2]);

                moviesDuration.Add(duration);

                if (genre != favoriteGenre)
                {
                    continue;
                }

                Movie movie = new Movie();

                movie.Name = name;
                movie.Info = duration;
                
                movies.Add(movie);
            }

            List<string> moviesList = new List<string>();
            if (movieDuration == "Short")
            {
                foreach (Movie movie in movies.OrderBy(a => a.Info).ThenBy(a => a.Name))
                {
                    moviesList.Add(movie.Name);
                }
            }
            else
            {
                foreach (Movie movie in movies.OrderByDescending(a => a.Info).ThenBy(a => a.Name))
                {
                    moviesList.Add(movie.Name);
                }
            }

            var counter = 0;
            while ((input = Console.ReadLine()) != "Yes")
            {
                var movieName = moviesList[counter];
                
                Console.WriteLine(movieName);

                counter++;
            }
            Console.WriteLine(moviesList[counter]);

            var movielastName = moviesList[counter];
            var timespan = new TimeSpan(moviesDuration.Sum(a => a.Ticks));
            Console.WriteLine($"We're watching {moviesList[counter]} - {movies.FirstOrDefault(a => a.Name == movielastName).Info}");
            Console.WriteLine($"Total Playlist Duration: {timespan}");
        }
    }

    public class Movie
    {
        public string Name { get; set; }

        public TimeSpan Info { get; set; }

    }
}
