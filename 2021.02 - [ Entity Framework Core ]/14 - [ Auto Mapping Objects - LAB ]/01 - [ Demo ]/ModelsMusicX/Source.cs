using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.ModelsMusicX
{
    public partial class Source
    {
        public Source()
        {
            ArtistMetadata = new HashSet<ArtistMetadatum>();
            SongMetadata = new HashSet<SongMetadatum>();
            Songs = new HashSet<Song>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadatum> ArtistMetadata { get; set; }
        public virtual ICollection<SongMetadatum> SongMetadata { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
