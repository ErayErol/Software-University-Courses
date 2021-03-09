using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.ModelsMusicX
{
    public partial class SongArtist
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public int Order { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Song Song { get; set; }
    }
}
