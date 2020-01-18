using EventWorld.Data.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventWorld.Services.Infrastructure
{
    public static class ServicesDependencyMapper
    {
        public static IServiceCollection GetDependencies(IServiceCollection services, IConfiguration configuration)
        {

            services = DataDependencyMapper.GetDependencies(services, configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
