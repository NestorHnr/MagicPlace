using MagicPlace_API.Models;

namespace MagicPlace_API.Respositories.IRespositories
{
    public interface IPlaceRepository : IRepository<Place>
    {
        Task<Place> PlaceUpdate(Place entidad);
    }
}
