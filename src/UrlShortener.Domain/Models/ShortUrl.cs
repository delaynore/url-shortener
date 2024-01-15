using UrlShortener.Domain.Common;
using UrlShortener.Domain.Exceptions.Token;

namespace UrlShortener.Domain.Models;

public class ShortUrl : ValueObject
{
    private const int MaxLength = 20;
    private ShortUrl(string value) => Value = value;
    public string Value { get; }

    public static ShortUrl Create(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new EmptyShortUrlException();
        }
        if (token.Length > MaxLength)
        {
            throw new InvalidShortUrlLengthException(token.Length);
        }

        return new ShortUrl(token);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}