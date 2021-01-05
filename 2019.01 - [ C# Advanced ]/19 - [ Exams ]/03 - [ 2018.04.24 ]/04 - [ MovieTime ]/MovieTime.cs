namespace _04.MovieTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Movie
    {
        public string Name { get; set; }

        public string Genre { get; set; }

        public TimeSpan Time { get; set; }
    }

    class MovieTime
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>();
            var favoruteGenre = Console.ReadLine();
            var shortOrLong = Console.ReadLine();
            var playlist = new TimeSpan();

            AllMovies(ref playlist, favoruteGenre, movies);
            Choose(shortOrLong, movies, playlist);
        }

        private static void Choose(string shortOrLong, List<Movie> movies, TimeSpan playlist)
        {
            if (shortOrLong == "Short")
            {
                foreach (var movie in movies.OrderBy(x => x.Time))
                {
                    if (Choosed(movie, playlist)) return;
                }
            }

            foreach (var movie in movies.OrderByDescending(x => x.Time))
            {
                if (Choosed(movie, playlist)) return;
            }
        }

        private static void AllMovies(ref TimeSpan playlist, string favoruteGenre, List<Movie> movies)
        {
            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "POPCORN!") break;
                var name = commands[0];
                var duration = commands[2].Split(':').Select(int.Parse).ToArray();
                var hours = duration[0];
                var minutes = duration[1];
                var seconds = duration[2];
                var time = new TimeSpan(hours, minutes, seconds);
                playlist += time;
                var genre = commands[1];
                if (genre == favoruteGenre)
                {
                    var movie = new Movie() { Name = name, Genre = genre, Time = time };
                    movies.Add(movie);
                }
            }
        }

        private static bool Choosed(Movie movie, TimeSpan playlist)
        {
            Console.WriteLine(movie.Name);
            var answer = Console.ReadLine();
            if (answer == "Yes")
            {
                Console.WriteLine(
                    $"We're watching {movie.Name} - {movie.Time.Hours:D2}:{movie.Time.Minutes:D2}:{movie.Time.Seconds:D2}");
                Console.WriteLine($"Total Playlist Duration: {playlist}");
                return true;
            }

            return false;
        }
    }
}