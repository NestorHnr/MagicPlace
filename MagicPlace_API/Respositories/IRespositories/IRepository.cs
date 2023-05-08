using System.Linq.Expressions;

namespace MagicPlace_API.Respositories.IRespositories
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entidad);

        Task<List<T>> GetAll(Expression<Func<T, bool>>? filtro = null, string? propertyInclude = null );

        Task<T> GetById(Expression<Func<T, bool>> filtro = null, bool tracked = true, string? propertyInclude = null);

        Task Delete(T entidad);

        Task Save();
    }
}
