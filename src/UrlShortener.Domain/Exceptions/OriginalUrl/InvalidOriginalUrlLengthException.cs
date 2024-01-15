using UrlShortener.Domain.Exceptions.Base;

namespace UrlShortener.Domain.Exceptions.OriginalUrl
{
    public sealed class InvalidOriginalUrlLengthException(int actual) : InvalidLengthException(nameof(OriginalUrl), Models.OriginalUrl.MaxLength, actual);
}
