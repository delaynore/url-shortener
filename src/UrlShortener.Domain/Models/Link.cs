using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Models;

public class Link : IEntity<int>
{
    public int Id { get; private set; }
    public Url OriginalUrl { get; private set; }
    public Token ShortUrl { get; private set; }
    
    private Link(int id, Url originalUrl, Token shortUrl)
    {
        Id = id;
        OriginalUrl = originalUrl;
        ShortUrl = shortUrl;
    }

    public static Link Create(int id, Url originalUrl, Token shortUrl)
    {
        //mb logic

        return new Link(id, originalUrl, shortUrl);
    }
}