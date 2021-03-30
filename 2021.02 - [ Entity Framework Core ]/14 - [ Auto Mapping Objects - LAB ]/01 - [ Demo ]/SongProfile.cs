namespace Demo
{
    using Demo.Dto;
    using Demo.ModelsMusicX;

    using AutoMapper;
    using System.Linq;

    public class SongProfile : Profile
    {
        public SongProfile()
        {
            this.CreateMap<Song, SongInfoDto>()
                .ForMember(dto => dto.Artists, opt =>
                {
                    opt.MapFrom(src =>
                        src.SongArtists.Select(s => s.Artist.Name));
                });
        }
    }
}
