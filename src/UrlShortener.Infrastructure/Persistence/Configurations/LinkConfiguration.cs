using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Domain.Models;

namespace UrlShortener.Infrastructure.Persistence.Configurations;

public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    private const int MaxLengthShortUrl = 20;
    private const int MaxLengthOriginalUrl = 200;
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(l => l.Id);
        
        builder.Property(l => l.ShortUrl)
            .HasConversion(x => x.Value,
                str => Url.Create(str))
            .HasMaxLength(MaxLengthShortUrl)
            .IsRequired();
        
        builder.Property(l => l.OriginalUrl)
            .HasConversion(x => x.Value,
                str => Url.Create(str))
            .HasMaxLength(MaxLengthOriginalUrl)
            .IsRequired();;
        
        builder.HasAlternateKey(l => l.ShortUrl);
    }
}