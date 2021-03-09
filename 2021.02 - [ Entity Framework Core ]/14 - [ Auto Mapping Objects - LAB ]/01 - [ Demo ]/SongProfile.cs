using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Demo.ModelsMusicX;

namespace Demo
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            this.CreateMap<Song, Program.SongInfoDTO>()
                .ForMember(dto => dto.Artists, opt =>
                {
                    opt.MapFrom(src =>
                        src.SongArtists.Select(s => s.Artist.Name));
                });
        }
    }
}
