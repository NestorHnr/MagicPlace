using MagicPlace_API.Respositories.IRespositories;
using MagicPlace_API.Respositories.ServicesRepositories;
using Microsoft.EntityFrameworkCore;

namespace MagicPlace_API.DataAdapters
{
    public static class Infraestructure
    {
            public static void AddDbContext(this IServiceCollection services,
                       IConfiguration configuration)
            {
                var conectionString = configuration.GetConnectionString("conexion");
                services.AddDbContext<ApplicationDbContext>(builder =>
                {
                    builder.UseSqlServer(conectionString);
                });

                services.AddHttpContextAccessor();
                services.AddRepositories();
                services.AddAutoMapper(typeof(MappingConfig));
            }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<ICategoryPlaceRepository, CategoryPlaceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
