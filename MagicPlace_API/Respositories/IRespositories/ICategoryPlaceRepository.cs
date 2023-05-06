using MagicPlace_API.Models;

namespace MagicPlace_API.Respositories.IRespositories
{
    public interface ICategoryPlaceRepository : IRepository<CategoryPlace>
    {
        Task<CategoryPlace> CategoryPlaceUpdate(CategoryPlace entidad);
    }
}
