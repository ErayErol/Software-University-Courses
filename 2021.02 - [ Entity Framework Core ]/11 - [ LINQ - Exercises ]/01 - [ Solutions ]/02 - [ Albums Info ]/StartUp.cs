namespace MusicHub
{
    using MusicHub.Data;
    using MusicHub.Initializer;

    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string NewLine = "\r\n";
        private const int ProducerId = 9;

        public static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();
            DbInitializer.ResetDatabase(context);
            var result = ExportAlbumsInfo(context, ProducerId);
            File.WriteAllText("../../../result.txt", result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(album => album.ProducerId == producerId)
                .Select(album => new
                {
                    album.Name,
                    ReleseaDate = album.ReleaseDate
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = album.Producer.Name,
                    Songs = album
                        .Songs
                        .Select(song => new
                        {
                            song.Name,
                            song.Price,
                            WriterName = song.Writer.Name,
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToList(),
                    Price = album
                        .Songs
                        .Sum(song => song.Price),
                })
                .OrderByDescending(album => album.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-Name: {album.Name}{NewLine}" +
                              $"-ReleaseDate: {album.ReleseaDate}{NewLine}" +
                              $"-ProducerName: {album.ProducerName}{NewLine}" +
                              "-Songs:");

                foreach (var song in album.Songs)
                {
                    int songNumber = album.Songs.IndexOf(song);
                    sb.AppendLine($"---#{++songNumber}{NewLine}" +
                                  $"---Name: {song.Name}{NewLine}" +
                                  $"---Price: {song.Price:F2}{NewLine}" +
                                  $"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-Price: {album.Price:F2}");
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