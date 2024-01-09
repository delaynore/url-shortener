using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Interfaces;

/// <summary>
/// Represents the interface for url shortening.
/// </summary>
public interface IUrlShortener
{
    /// <summary>
    /// Encode the source url.
    /// </summary>
    /// <param name="url">Original url.</param>
    /// <returns>Shorten url.</returns>
    Task<Url> ShortUrl(Url url);
}