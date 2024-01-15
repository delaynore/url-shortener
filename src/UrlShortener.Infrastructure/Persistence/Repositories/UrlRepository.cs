using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Interfaces.Repositories;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Persistence.Repositories;

public class UrlRepository(AppDbContext dbContext) : IUrlRepository
{
    public Task<ShortUrl> Create(Link link, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            await dbContext.Links.AddAsync(link, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return link.ShortUrl;
        }, cancellationToken);
    }
    
    public async Task<OriginalUrl?> GetByShortUrl(ShortUrl shortUrl, CancellationToken cancellationToken)
    { 
        return (await dbContext.Links.SingleOrDefaultAsync(l => l.ShortUrl == shortUrl, cancellationToken))?.OriginalUrl;
    }
}