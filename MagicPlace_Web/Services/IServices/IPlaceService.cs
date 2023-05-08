using MagicPlace_Web.Dto;

namespace MagicPlace_Web.Services.IServices
{
    public interface IPlaceService
    {
        Task<T> GetAll<T>();
        Task<T> GetById<T>(int id);
        Task<T> Create<T>(PlaceCreateDto dto);
        Task<T> Update<T>(PlaceUpdateDto dto);
        Task<T> Delete<T>(int id);
    }
}
