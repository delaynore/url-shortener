namespace UrlShortener.Domain.Tests;

public class ShortUrlTests
{
    [Fact]
    public void OriginalUrl_Should_Created_When_Url_Valid()
    {
        var url = "sfsdfasdf";

        var shortUrl = ShortUrl.Create(url);

        Assert.NotNull(shortUrl);
        Assert.Equal(url, shortUrl.Value);
    }

    [Fact]
    public void OriginalUrl_Should_Throw_Exception_When_Length_Over_Than_Max_But_Url_Valid()
    {
        var url = new string('r', 21);

        Assert.Throws<InvalidShortUrlLengthException>(() => ShortUrl.Create(url));
    }

    [Theory]
    [InlineData("   ")]
    [InlineData(null)]
    public void OriginalUrl_Should_Throw_Exception_When_Url_NullOrWhitespaces(string? url)
    {

        Assert.Throws<EmptyShortUrlException>(() => ShortUrl.Create(url!));
    }

}
