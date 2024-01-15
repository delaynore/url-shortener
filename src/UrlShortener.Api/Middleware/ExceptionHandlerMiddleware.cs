using UrlShortener.Domain.Exceptions.Base;
using UrlShortener.Domain.Exceptions.OriginalUrl;

namespace UrlShortener.Api.Middleware
{
    public sealed class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    Code = GetStatusCodes(ex),
                    ex.Message
                };
                context.Response.StatusCode = response.Code;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(response);
            }
        }

        private int GetStatusCodes(Exception exception)
        {
            return exception switch
            {
                OriginalUrlNotFoundException => StatusCodes.Status404NotFound,
                BaseException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
