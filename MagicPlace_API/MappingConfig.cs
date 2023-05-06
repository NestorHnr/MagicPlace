using AutoMapper;
using MagicPlace_API.Dto;
using MagicPlace_API.Models;

namespace MagicPlace_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Place, PlaceDto>().ReverseMap();
            CreateMap<Place, PlaceCreateDto>().ReverseMap();
            CreateMap<Place, PlaceUpdateDto>().ReverseMap();

            //CreateMap<NumberVilla, NumberVillaDto>().ReverseMap();
            //CreateMap<NumberVilla, NumberVillaCreateDto>().ReverseMap();
            //CreateMap<NumberVilla, NumberVillaUpdateDto>().ReverseMap();
        }
    }
}
