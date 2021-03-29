namespace Demo
{
    using Demo.ModelsMusicX;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var db = new MusicXContext();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<SongProfile>());
            var songs = db.Songs
                .Where(s => s.Name.StartsWith("С"))
                .ProjectTo<SongInfoDTO>(config)
                .ToList();
        }

        public class SongInfoDTO
        {
            public string Name { get; set; }

            public string SourceName { get; set; }

            public List<string> Artists { get; set; }
        }
    }
}
