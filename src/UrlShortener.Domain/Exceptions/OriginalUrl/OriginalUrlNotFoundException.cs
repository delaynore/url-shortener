using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.OriginalUrl
{
    public sealed class OriginalUrlNotFoundException(string url) : BaseException($"{url} is not found");
}
