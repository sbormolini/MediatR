using MediatR;
using MediatRDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers;

[ApiController]
[Route("api")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        ILogger<WeatherForecastController> 
        logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("weather/{city}")]
    public async Task<IActionResult> GetForecast([FromRoute] string city)
    {
        var request = new GetWeatherRequest(city);
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("weather-warning")]
    public async Task<IActionResult> CreateWarning([FromBody] WeatherWarning warning)
    {
        var notification = new WeatherWarningNotification(warning.Message);
        await _mediator.Publish(notification);
        return Ok(notification);
    }

    [HttpGet("weather-updates/{city}")]
    public IAsyncEnumerable<WeatherForecast> WeatherUpdates(
        [FromRoute] string city, 
        CancellationToken cancellationToken)
    {
        var streamRequest = new WeatherUpdateStreamRequest(city);
        return _mediator.CreateStream(streamRequest, cancellationToken);
    }
}