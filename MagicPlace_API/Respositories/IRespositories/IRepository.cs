using System.Linq.Expressions;

namespace MagicPlace_API.Respositories.IRespositories
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entidad);

        Task<List<T>> GetAll(Expression<Func<T, bool>>? filtro = null);

        Task<T> GetById(Expression<Func<T, bool>> filtro = null, bool tracked = true);

        Task Delete(T entidad);

        Task Save();
    }
}
