using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.Url
{
    public sealed class InvalidUrlLengthException(int actual) : InvalidLengthException("Url", 200, actual);
}
