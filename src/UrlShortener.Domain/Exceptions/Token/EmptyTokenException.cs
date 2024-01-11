using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.Token
{
    public sealed class EmptyTokenException() : EmptyValueException("Token");
}
