using MagicPlace_API.DataAdapters;
using MagicPlace_API.Respositories.IRespositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace MagicPlace_API.Respositories.ServicesRepositories
{
        public class ServiceRepository<T> : IRepository<T> where T : class
        {
            private readonly ApplicationDbContext _context;
            internal DbSet<T> dbSet;

            public ServiceRepository(ApplicationDbContext context)
            {
                _context = context;
                this.dbSet = _context.Set<T>();
            }

            public async Task Create(T entidad)
            {
                await dbSet.AddAsync(entidad);
                await Save();
            }

            public async Task Delete(T entidad)
            {
                dbSet.Remove(entidad);
                await Save();
            }

            public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filtro = null)
            {
                IQueryable<T> query = dbSet;
                if (filtro != null)
                {
                    query = query.Where(filtro);
                }
                return await query.ToListAsync();
            }

            public async Task<T> GetById(Expression<Func<T, bool>> filtro = null, bool tracked = true)
            {
                IQueryable<T> query = dbSet;
                if (!tracked)
                {
                    query = query.AsNoTracking();
                }
                if (filtro != null)
                {
                    query = query.Where(filtro);
                }
                return await query.FirstOrDefaultAsync();
            }

            public async Task Save()
            {
                await _context.SaveChangesAsync();
            }
        }
    }
