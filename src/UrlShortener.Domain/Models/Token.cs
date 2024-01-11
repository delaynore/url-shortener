using UrlShortener.Domain.Common;
using UrlShortener.Domain.Exceptions.Token;

namespace UrlShortener.Domain.Models;

public class Token : ValueObject
{
    private const int MaxLength = 20;
    private Token(string value) => Value = value;
    public string Value { get; }

    public static Token Create(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new EmptyTokenException();
        }
        if (token.Length > MaxLength)
        {
            throw new InvalidTokenLengthException(token.Length);
        }

        return new Token(token);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}