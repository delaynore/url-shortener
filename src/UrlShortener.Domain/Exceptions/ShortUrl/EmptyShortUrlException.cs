using UrlShortener.Domain.Exceptions.Base;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Exceptions.ShortUrl
{
    public sealed class EmptyShortUrlException() : EmptyValueException(nameof(ShortUrl));
}
