using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Dto;
using UrlShortener.Application.Interfaces.Services;

namespace UrlShortener.Api.Controllers;

[Route("")]
[ApiController]
public class UrlController(IUrlService urlService) : ControllerBase
{
    private readonly IUrlService _urlService = urlService;
    
    [HttpGet("")]
    public async Task<IActionResult> ShortenUrl([FromQuery] UrlDto urlDto)
    {
        var shortenUrl = await _urlService.ShortenUrl(urlDto, default);
        var host = HttpContext.Request.Host.ToString();
        return Ok(new UrlDto(host + "/" + shortenUrl.Url));
    }
    
    [HttpGet("{shortUrl}")]
    public async Task<IActionResult> ShortenUrl(string shortUrl)
    {
        var urlDto = new UrlDto(shortUrl);
        var originalUrl = await _urlService.ExpandUrl(urlDto, default);
        return Ok(originalUrl);
    }
}