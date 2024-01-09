using UrlShortener.Domain.Interfaces.Repositories;

namespace UrlShortener.Domain.Entities;

public class Link
{
    public int Id { get; private set; }
    public Url OriginalUrl { get; private set; }
    public Url ShortUrl { get; private set; }
    
    private Link(int id, Url originalUrl, Url shortUrl)
    {
        Id = id;
        OriginalUrl = originalUrl;
        ShortUrl = shortUrl;
    }

    public static Link Create(int id, Url originalUrl, Url shortUrl)
    {
        //mb logic

        return new Link(id, originalUrl, shortUrl);
    }
}