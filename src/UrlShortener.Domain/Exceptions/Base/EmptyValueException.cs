namespace UrlShortener.Domain.Exceptions.Base
{
    public abstract class EmptyValueException(string field) : BaseException($"'{field}' can't be an empty value");
}
