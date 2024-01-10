using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Models;

public class Token : ValueObject
{
    private Token(string value) => Value = value;
    public string Value { get; }

    public static Token Create(string token)
    {
        return new Token(token);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}