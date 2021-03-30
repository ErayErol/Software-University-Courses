namespace Demo
{
    using Demo.Dto;
    using Demo.ModelsMusicX;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<SongProfile>());
            var db = new MusicXContext();
            var songs = db.Songs
                .Where(s => s.Name.StartsWith("E"))
                .ProjectTo<SongInfoDto>(config)
                .ToList();

            foreach (var song in songs)
            {
                foreach (var songArtist in song.Artists)
                {
                    Console.WriteLine($"-{songArtist}");
                }
                Console.WriteLine($"---{song.Name}");
            }
        }
    }
}
