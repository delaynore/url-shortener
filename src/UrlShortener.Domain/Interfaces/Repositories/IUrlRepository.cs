using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Interfaces.Repositories;

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
    Task<Url> Create(Link link, CancellationToken cancellationToken);
    
    /// <summary>
    /// Get the original url by short url.
    /// </summary>
    /// <param name="shortUrl">Short url.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Decoded url if found otherwise null.</returns>
    Task<Url?> GetByShortUrl(Url shortUrl, CancellationToken cancellationToken);
    
    /// <summary>
    /// Delete the link by id.
    /// </summary>
    /// <param name="id">The id of link/</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task Delete(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Gets all link.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of links</returns>
    Task<ICollection<Link>> GetAllUrls(CancellationToken cancellationToken);
}