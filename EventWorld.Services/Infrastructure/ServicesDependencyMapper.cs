using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using EventWorld.Services.Logic;
using EventWorld.Services.Services.Events;
using EventWorld.Services.Services.EventTypes;
using EventWorld.Services.Services.Messages;
using EventWorld.Services.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventWorld.Services.Infrastructure
{
    public static class ServicesDependencyMapper
    {
        public static IServiceCollection GetDependencies(IServiceCollection services, IConfiguration configuration)
        {

            services = DataDependencyMapper.GetDependencies(services, configuration);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddScoped<IUserStore<UserDTO>, UserStore>();

            return services;
        }
    }
}
