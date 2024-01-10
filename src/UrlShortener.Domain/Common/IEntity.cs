namespace UrlShortener.Domain.Common;

public interface IEntity<out TId> where TId : IComparable<TId>, IEquatable<TId>
{
    public TId Id { get; }
}