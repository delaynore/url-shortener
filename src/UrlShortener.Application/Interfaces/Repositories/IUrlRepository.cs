using UrlShortener.Domain.Models;

namespace UrlShortener.Application.Interfaces.Repositories;

/// <summary>
/// Represent the api for manage urls.
/// </summary>
public interface IUrlRepository
{
    /// <summary>
    /// Create a new link.
    /// </summary>
    /// <param name="link">Link.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task<Token> Create(Link link, CancellationToken cancellationToken);
    
    /// <summary>
    /// Get the original url by short url.
    /// </summary>
    /// <param name="shortUrl">Short url.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Decoded url if found otherwise null.</returns>
    Task<Token?> GetByShortUrl(Token shortUrl, CancellationToken cancellationToken);
}