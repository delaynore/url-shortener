using UrlShortener.Domain.Exceptions.Base;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Exceptions.Url
{
    public sealed class InvalidOriginalUrlLengthException(int actual) : InvalidLengthException(nameof(OriginalUrl), 200, actual);
}
