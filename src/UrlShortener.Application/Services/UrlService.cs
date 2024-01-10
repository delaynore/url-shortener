using UrlShortener.Application.Dto;
using UrlShortener.Application.Interfaces.Repositories;
using UrlShortener.Application.Interfaces.Services;
using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Services;

public class UrlService(IUrlRepository repository, IUrlShortener urlShortener) : IUrlService
{
    public async Task<UrlDto> ShortenUrl(UrlDto originalUrl, CancellationToken cancellationToken = default)
    {
        var original = Url.Create(originalUrl.Url);
        var shorted = await urlShortener.Short(original);
        
        var link = Link.Create(0, original, shorted); //some questions about id = 0
        return new UrlDto((await repository.Create(link, cancellationToken)).Value);
    }

    public async Task<UrlDto> ExpandUrl(UrlDto shortUrl, CancellationToken cancellationToken = default)
    {
        var url = Url.Create(shortUrl.Url);
        var expandedUrl = await repository.GetByShortUrl(url, cancellationToken);
        
        if (expandedUrl is null) throw new Exception(shortUrl + " is not found");
        return new UrlDto(expandedUrl.Value);
    }
}