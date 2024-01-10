using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Application.Interfaces.Services;
using UrlShortener.Application.Services;

namespace UrlShortener.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUrlService, UrlService>();
        return services;
    }
}