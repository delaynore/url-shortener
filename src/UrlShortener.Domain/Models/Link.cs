using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Models;

public class Link : IEntity<int>
{
    public int Id { get; private set; }
    public OriginalUrl OriginalUrl { get; private set; }
    public ShortUrl ShortUrl { get; private set; }
    
    private Link(int id, OriginalUrl originalUrl, ShortUrl shortUrl)
    {
        Id = id;
        OriginalUrl = originalUrl;
        ShortUrl = shortUrl;
    }

    public static Link Create(int id, OriginalUrl originalUrl, ShortUrl shortUrl)
    {
        //mb logic

        return new Link(id, originalUrl, shortUrl);
    }
}