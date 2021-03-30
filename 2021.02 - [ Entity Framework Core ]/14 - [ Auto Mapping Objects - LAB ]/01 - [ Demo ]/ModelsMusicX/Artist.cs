namespace Demo.ModelsMusicX
{
    using System;
    using System.Collections.Generic;

    public partial class Artist
    {
        public Artist()
        {
            ArtistMetadata = new HashSet<ArtistMetadatum>();
            SongArtists = new HashSet<SongArtist>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadatum> ArtistMetadata { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
    }
}
