namespace MusicHub
{
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp

    {
        const string NewLine = "\r\n";

        public static void Main(string[] args)
        {

            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            var result = ExportAlbumsInfo(context, 9);
            Console.WriteLine(result);
            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();
            var albumInfo = context
                .Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(a => new
                {
                    AlbumName = a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs.Select(s => new
                    {
                        SognName = s.Name,
                        SongPrice = s.Price,
                        SongWriterName = s.Writer.Name,
                    })
                    .OrderByDescending(s => s.SognName)
                    .ThenBy(s => s.SongWriterName)
                    .ToList(),
                    AlbumPrice = a.Songs.Sum(z => z.Price)
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();

            foreach (var album in albumInfo)
            {
                var releaseDate = album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                sb.AppendLine($"-AlbumName: {album.AlbumName}{NewLine}" +
                              $"-ReleaseDate: {releaseDate}{NewLine}" +
                              $"-ProducerName: {album.ProducerName}{NewLine}" +
                              "-Songs:");

                var songCount = 0;
                foreach (var albumSong in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{++songCount}{NewLine}" +
                                  $"---SongName: {albumSong.SognName}{NewLine}" +
                                  $"---Price: {albumSong.SongPrice:F2}{NewLine}" +
                                  $"---Writer: {albumSong.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
