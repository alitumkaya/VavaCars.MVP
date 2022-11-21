using AutoMapper;
using VavaCars.MVP.ConsoleApp.Domain;

namespace VavaCars.MVP.ConsoleApp.AppServices
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PlayerBase, PlayerDto>()
                .ForMember(f => f.RatingPoints, opt => opt.MapFrom(m => m.GetRatingPoints()));
        }
    }
}
