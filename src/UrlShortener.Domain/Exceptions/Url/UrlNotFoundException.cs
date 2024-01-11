using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.Url
{
    public sealed class UrlNotFoundException(string url) : BaseException($"{url} is not found");
}
