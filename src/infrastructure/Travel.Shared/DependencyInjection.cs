using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel.Application.Commons.Interfaces;
using Travel.Domain.Settings;
using Travel.Shared.Files;
using Travel.Shared.Services;

namespace Travel.Shared
{
    public static class DependencyInjection
    {
        // i removed the this reference from the parameter bracket
        public static IServiceCollection AddInfrastructureShared ( this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IEmailService, EmailServices>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            return services;
        }
    }
}