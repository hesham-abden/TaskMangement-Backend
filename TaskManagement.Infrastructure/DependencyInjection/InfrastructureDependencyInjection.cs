using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Contracts.Infrastructure;
using TaskManagement.Infrastructure.Mail;
using TaskManagement.Infrastructure.Payment;

namespace TaskManagement.Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // configuration["Payment"]
            // configuration.GetSection("EmailSettings")
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPaymentService, PaymentService>();
            return services;
        }
    }
}
