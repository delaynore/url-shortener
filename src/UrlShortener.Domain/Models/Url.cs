using System.Text.RegularExpressions;
using UrlShortener.Domain.Common;
using UrlShortener.Domain.Exceptions.Url;

namespace UrlShortener.Domain.Models;

public class Url : ValueObject
{
    private const int MaxLength = 200;
    public string Value { get; }
    
    private Url(string value)
    {
        Value = value;
    }

    public static Url Create(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new EmptyUrlException();
        }
        if (url.Length > MaxLength)
        {
            throw new InvalidUrlLengthException(url.Length);
        }
        if (!IsValidUrl(url))
        {
            throw new InvalidUrlException(url);
        }

        return new Url(url);
    }

    private const string UrlPattern =
        @"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    private static bool IsValidUrl(string url) => Regex.IsMatch(url, UrlPattern);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}