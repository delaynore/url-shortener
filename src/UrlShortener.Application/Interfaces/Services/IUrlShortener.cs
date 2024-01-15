using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces.Services;

public interface IUrlShortener
{
    Task<ShortUrl> Short(OriginalUrl originalUrl);
}