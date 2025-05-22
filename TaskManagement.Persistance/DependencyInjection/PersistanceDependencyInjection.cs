using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Contracts.Persistance.Repositories;
using TaskManagement.Domain.Repositories;
using TaskManagement.Persistance.Context;
using UserManagement.Application.Contracts.Persistance.Repositories;

namespace TaskManagement.Persistance.DependencyInjection
{
    public static class PersistanceDependencyInjection
    {
        public static IServiceCollection AddPersistanceLayerDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<TaskAppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Database");
                options.UseSqlServer(connectionString);
            });

            // Add Repositories
            // Infrastructure layer DI registration
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Add Unit Of Work

            return services;
        }
    }
}
