using EventWorld.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventWorld.Data.Infrastructure
{
    public static class DataDependencyMapper
    {
        public static IServiceCollection GetDependencies(IServiceCollection services, IConfiguration configuration)
        {

            var connection = configuration.GetConnectionString("EventWorldConnectionString");
            services.AddDbContext<EventWorldDataContext>(options => options.UseSqlServer(connection));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
