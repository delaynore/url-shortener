using UrlShortener.Application.Interfaces.Services;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Services;

public class UrlShortener : IUrlShortener
{
    private const int ShortUrlLength = 6;

    private const string AllowedCharacters = "1234567890" +
                                             "qwertyuiopasdfghjklzxcvbnm" +
                                             "QWERTYUIOPASDFGHJKLZXCVBNM";
    private Url GetShortenUrl(Url _)
    {
        var random = Random.Shared;
        return Url.Create(new string(random.GetItems<char>(AllowedCharacters, ShortUrlLength)));
    }

    public Task<Url> Short(Url originalUrl)
    {
        return new Task<Url>(() => GetShortenUrl(originalUrl));
    }
}