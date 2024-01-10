using UrlShortener.Application.Dto;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces.Services;

public interface IUrlService
{
    Task<UrlDto> ShortenUrl(UrlDto originalUrl, CancellationToken cancellationToken);
    Task<UrlDto> ExpandUrl(UrlDto shortUrl, CancellationToken cancellationToken);
}