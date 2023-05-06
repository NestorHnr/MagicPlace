using MagicPlace_API.DataAdapters;
using MagicPlace_API.Models;
using MagicPlace_API.Respositories.IRespositories;

namespace MagicPlace_API.Respositories.ServicesRepositories
{
    public class PlaceRepository : ServiceRepository<Place> , IPlaceRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Place> PlaceUpdate(Place entidad)
        {
            entidad.DateUpdate = DateTime.Now;
            _context.Places.Update(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }
    }
}
