using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Interfaces.Services;

/// <summary>
/// Represents the interface for decode and encode urls.
/// </summary>
public interface IUrlService
{
    Task EncodeUrl(Url originalUrl);
    Task DecodeUrl(Url shortUrl);
}