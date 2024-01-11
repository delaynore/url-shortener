namespace UrlShortener.Domain.Exceptions.Base
{
    public abstract class InvalidLengthException(string field, int max, int actual)
        : BaseException($"The '{field}' length should be between 0 and {max} but actual is {actual}");
}
