namespace Demo.ModelsMusicX
{
    using System;
    using System.Collections.Generic;

    public partial class Song
    {
        public Song()
        {
            SongArtists = new HashSet<SongArtist>();
            SongMetadata = new HashSet<SongMetadatum>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }
        public string SearchTerms { get; set; }

        public virtual Source Source { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<SongMetadatum> SongMetadata { get; set; }
    }
}
