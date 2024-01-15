using UrlShortener.Application.Interfaces.Services;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Services;

public class UrlShortener : IUrlShortener
{
    private const int ShortUrlLength = 6;

    private const string AllowedCharacters = "1234567890" +
                                             "qwertyuiopasdfghjklzxcvbnm" +
                                             "QWERTYUIOPASDFGHJKLZXCVBNM";
    private ShortUrl GetShortenUrl(OriginalUrl _)
    {
        var random = Random.Shared;
        return ShortUrl.Create(new string(random.GetItems<char>(AllowedCharacters, ShortUrlLength)));
    }

    public Task<ShortUrl> Short(OriginalUrl originalUrl)
    {
        return Task.Run(() => GetShortenUrl(originalUrl));
    }
}