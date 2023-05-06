using MagicPlace_API.DataAdapters;
using MagicPlace_API.Models;
using MagicPlace_API.Respositories.IRespositories;

namespace MagicPlace_API.Respositories.ServicesRepositories
{
    public class CategoryPlaceRepository : ServiceRepository<CategoryPlace> , ICategoryPlaceRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryPlaceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CategoryPlace> CategoryPlaceUpdate(CategoryPlace entidad)
        {
            entidad.UpdateTime = DateTime.Now;
            _context.CategoriesPlaces.Update(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }
    }
}
