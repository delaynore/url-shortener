﻿using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Interfaces.Repositories;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Persistence.Repositories;

public class UrlRepository(AppDbContext dbContext) : IUrlRepository
{
    public Task<Url> Create(Link link, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            await dbContext.Links.AddAsync(link, cancellationToken);
            return link.ShortUrl;
        }, cancellationToken);
    }

    public async Task<Url?> GetByShortUrl(Url shortUrl, CancellationToken cancellationToken)
    { 
        return (await dbContext.Links.SingleOrDefaultAsync(l => l.ShortUrl == shortUrl, cancellationToken))?.ShortUrl;
    }
}