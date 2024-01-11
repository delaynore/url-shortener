using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.Url
{
    public sealed class EmptyUrlException() : EmptyValueException("Url");
}
