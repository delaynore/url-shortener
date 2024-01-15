using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using UrlShortener.Application.Dto;
using UrlShortener.Application.Interfaces.Services;

namespace UrlShortener.Api.Controllers;

[Route("")]
[Consumes("application/json")]
[Produces("application/json")]
public class UrlController(IUrlService urlService) : ControllerBase
{
    private readonly IUrlService _urlService = urlService;

    /// <summary>
    /// Shorten the original url.
    /// </summary>
    /// <param name="urlDto">The original url.</param>
    /// <returns>The shorten url.</returns>
    [ProducesResponseType(typeof(UrlDto),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("")]
    public async Task<IActionResult> ShortenUrl([FromQuery] UrlDto urlDto)
    {
        var shortenUrl = await _urlService.ShortenUrl(urlDto, default);
        var host = HttpContext.Request.Host.ToString();
        return Ok(new UrlDto(host + "/" + shortenUrl.Url));
    }

    /// <summary>
    /// Get the original url by short url.
    /// </summary>
    /// <param name="shortUrl">The short url.</param>
    /// <returns>The original url.</returns>
    [ProducesResponseType(typeof(UrlDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("{shortUrl}")]
    public async Task<IActionResult> ShortenUrl(string shortUrl)
    {
        var urlDto = new UrlDto(shortUrl);
        var originalUrl = await _urlService.ExpandUrl(urlDto, default);
        return Ok(originalUrl);
    }
}