using MediatR;
using MediatRDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatRDemo.Controllers;

[ApiController]
[Route("[controller]")]
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
}