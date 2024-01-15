using UrlShortener.Domain.Exceptions.Base;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Exceptions.Url
{
    public sealed class EmptyOriginalUrlException() : EmptyValueException(nameof(OriginalUrl));
}
