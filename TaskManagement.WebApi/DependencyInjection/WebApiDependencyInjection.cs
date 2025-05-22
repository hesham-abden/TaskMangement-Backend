using Microsoft.AspNetCore.Identity;
using TaskManagement.Application.Contracts.Persistance.Context;
using TaskManagement.Application.DependencyInjection;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Identity;
using TaskManagement.Infrastructure.DependencyInjection;
using TaskManagement.Persistance.Context;
using TaskManagement.Persistance.DependencyInjection;

namespace TaskManagement.WebApi.DependencyInjection
{
    public static class WebApiDependencyInjection
    {
        public static void AddWebApiLayerDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            AddPreLayers(services, configuration);
        }
        public static void AddPreLayers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistanceLayerDependencyInjection(configuration);
            services.AddInfrastructureDependencyInjection(configuration);
            services.AddApplicationLayerDependencyInjection();
        }
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services
                 .AddIdentity<User, Role>(options =>
                 {
                     options.Password.RequireUppercase = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.User.RequireUniqueEmail = false;
                 })
                    .AddEntityFrameworkStores<TaskAppDbContext>();
            return services;
        }

        public static IServiceCollection AddCorsServices(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: policyName, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
