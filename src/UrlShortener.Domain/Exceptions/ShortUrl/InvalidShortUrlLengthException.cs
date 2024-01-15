using UrlShortener.Domain.Exceptions.Base;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Exceptions.Token
{
    public sealed class InvalidShortUrlLengthException(int actual)
        : InvalidLengthException(nameof(ShortUrl), 20, actual);
}
