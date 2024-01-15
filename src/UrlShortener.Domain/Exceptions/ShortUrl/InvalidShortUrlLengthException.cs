using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.ShortUrl
{
    public sealed class InvalidShortUrlLengthException(int actual)
        : InvalidLengthException(nameof(ShortUrl), Models.ShortUrl.MaxLength, actual);
}
