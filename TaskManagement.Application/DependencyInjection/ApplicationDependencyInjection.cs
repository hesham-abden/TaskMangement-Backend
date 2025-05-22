using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManagement.Application.Interfaces.Services;
using TaskManagement.Application.Services;

namespace TaskManagement.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationLayerDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
