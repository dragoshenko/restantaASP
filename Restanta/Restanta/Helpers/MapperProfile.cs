using AutoMapper;
using Restanta.Models.Dtos;
using Restanta.Models;

namespace Restanta.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {   /*
            CreateMap<Actor, ActorDto>();

            CreateMap<Film, FilmDto>();
            */


            
            CreateMap<Actor, ActorDto>().ReverseMap();

            CreateMap<Film, FilmDto>().ReverseMap();

            CreateMap<ActoriFilme, ActoriFilmeDto>()
                .ForMember(dest => dest.Actor, opt => opt.MapFrom(src => src.Actor))
                .ForMember(dest => dest.Film, opt => opt.MapFrom(src => src.Film))
                .ReverseMap();
            
        }
    }
}
