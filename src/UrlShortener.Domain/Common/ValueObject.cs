namespace UrlShortener.Domain.Common;

public abstract class ValueObject : IEquatable<ValueObject>
{

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ValueObject)obj);
    }
    
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
    
    public bool Equals(ValueObject? other)
    {
        if (ReferenceEquals(this, null) ^ ReferenceEquals(other, null)) return false;
        return ReferenceEquals(this, other) || GetEqualityComponents().SequenceEqual(other!.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !Equals(left, right);
    }
}