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

            CreateMap<CategoryPlace, CategoryPlaceDto>().ReverseMap();
            CreateMap<CategoryPlace, CategoryCreatePlaceDto>().ReverseMap();
            CreateMap<CategoryPlace, CategoryUpdatePlaceDto>().ReverseMap();
        }
    }
}
