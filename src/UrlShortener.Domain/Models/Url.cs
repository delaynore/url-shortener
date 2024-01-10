using System.Text.RegularExpressions;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Models;

public class Url : ValueObject
{
    public string Value { get; }
    
    private Url(string value)
    {
        Value = value;
    }

    public static Url Create(string url)
    {
        if (!IsValidUrl(url))
        {
            throw new ArgumentException(nameof(url) + " is not valid");
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