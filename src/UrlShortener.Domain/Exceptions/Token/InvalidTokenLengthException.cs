using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.Token
{
    public sealed class InvalidTokenLengthException(int actual)
        : InvalidLengthException("Token", 20, actual);
}
