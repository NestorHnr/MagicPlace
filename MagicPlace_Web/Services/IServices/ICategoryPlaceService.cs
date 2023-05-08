using MagicPlace_Web.Dto;

namespace MagicPlace_Web.Services.IServices
{
    public interface ICategoryPlaceService
    {
        Task<T> GetAll<T>();
        Task<T> GetById<T>(int id);
        Task<T> Create<T>(CategoryCreatePlaceDto dto);
        Task<T> Update<T>(CategoryUpdatePlaceDto dto);
        Task<T> Delete<T>(int id);
    }
}
