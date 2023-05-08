using AutoMapper;
using MagicPlace_Web.Dto;

namespace MagicPlace_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PlaceDto, PlaceCreateDto>().ReverseMap();
            CreateMap<PlaceDto, PlaceUpdateDto>().ReverseMap();

            CreateMap<CategoryPlaceDto, CategoryCreatePlaceDto>().ReverseMap();
            CreateMap<CategoryPlaceDto, CategoryUpdatePlaceDto>().ReverseMap();

        }
    }
}
