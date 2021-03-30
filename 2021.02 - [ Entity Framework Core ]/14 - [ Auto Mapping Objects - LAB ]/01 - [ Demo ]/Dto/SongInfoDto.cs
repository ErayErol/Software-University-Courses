namespace Demo.Dto
{
    using System.Collections.Generic;

    public class SongInfoDto
    {
        public string Name { get; set; }

        public string SourceName { get; set; }

        public List<string> Artists { get; set; }
    }
}
