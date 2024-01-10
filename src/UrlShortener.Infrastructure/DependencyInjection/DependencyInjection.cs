using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.Interfaces.Repositories;
using UrlShortener.Application.Interfaces.Services;
using UrlShortener.Infrastructure.Persistence;
using UrlShortener.Infrastructure.Persistence.Repositories;

namespace UrlShortener.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddAdditionalServices();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });
        services.AddScoped<IUrlRepository, UrlRepository>();
        
        return services;
    }
    
    private static IServiceCollection AddAdditionalServices(this IServiceCollection services)
    {
        services.AddScoped<IUrlShortener, Services.UrlShortener>();
        return services;
    }
}