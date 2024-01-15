using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.OriginalUrl
{
    public sealed class InvalidOriginalUrlException(string url) : BaseException($"Original url '{url}' is not valid ");
}
