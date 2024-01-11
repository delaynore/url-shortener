using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.Url
{
    public sealed class InvalidUrlException(string url) : BaseException($"Url '{url}' is not valid ");
}
