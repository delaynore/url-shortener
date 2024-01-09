using System.Text.RegularExpressions;

namespace UrlShortener.Domain.Entities;

public class Url
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

    private const string urlPattern =
        @"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    private static bool IsValidUrl(string url) => Regex.IsMatch(url, urlPattern);
}