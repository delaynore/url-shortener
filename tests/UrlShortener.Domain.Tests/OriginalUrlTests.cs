namespace UrlShortener.Domain.Tests;

public class OriginalUrlTests
{
    [Fact]
    public void OriginalUrl_Should_Created_When_Url_Valid()
    {
        var url = "https://vk.com/al_feed.php";

        var originalUrl = OriginalUrl.Create(url);

        Assert.NotNull(originalUrl);
        Assert.Equal(url, originalUrl.Value);
    }

    [Fact]
    public void OriginalUrl_Should_Throw_Exception_When_Length_Over_Than_Max_But_Url_Valid()
    {
        var url = """
            https://vk.com/fa/d/fa/df/a/df/d/fs/df/s/fsd/f
            /sdf/sd/f/af/sda/f/sdf/sdf/sadf/sd/fsd/ffadsf/adfadsf/
            adfadsf/adsfasdf/asdfasdf/asdf/asdfa/sdf/adsfsadf/dgds
            af/asdfasdf/asdfasdf/asdfasdf/asdfsadfasdfsadf/asdfadsf/adf
            """;

        Assert.Throws<InvalidOriginalUrlLengthException>(() => OriginalUrl.Create(url));
    }

    [Theory]
    [InlineData("   ")]
    [InlineData(null)]
    public void OriginalUrl_Should_Throw_Exception_When_Url_NullOrWhitespaces(string? url)
    {

        Assert.Throws<EmptyOriginalUrlException>(() => OriginalUrl.Create(url!));
    }

    [Theory]
    [InlineData("fasdfsdf")]
    [InlineData("fa/fad/fa/a")]
    public void OriginalUrl_Should_Throw_Exception_When_Url_Not_Valid(string url)
    {

        Assert.Throws<InvalidOriginalUrlException>(() => OriginalUrl.Create(url));
    }

    [Theory]
    [InlineData("https://www.google.com/", "https://www.google.com/")]
    public void OriginalUrl_ValueObject_Equals(string url1, string url2)
    {
        var originalUrl1 = OriginalUrl.Create(url1);
        var originalUrl2 = OriginalUrl.Create(url2);
        Assert.True(originalUrl1 == originalUrl2);
        Assert.True(originalUrl1.Equals(originalUrl2));
        Assert.False(originalUrl1 != originalUrl2);
    }

    [Theory]
    [InlineData("https://www.google.com/", "https://www.google.com/search")]
    public void OriginalUrl_ValueObject_NotEquals(string url1, string url2)
    {
        var originalUrl1 = OriginalUrl.Create(url1);
        var originalUrl2 = OriginalUrl.Create(url2);
        Assert.False(originalUrl1 == originalUrl2);
        Assert.False(originalUrl1.Equals(originalUrl2));
        Assert.True(originalUrl1 != originalUrl2);
    }
}