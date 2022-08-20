using MediatR;
using MediatRDemo.Models;

namespace MediatRDemo.Handlers;

public class GetWeatherForecastHandler : 
    IRequestHandler<GetWeatherRequest, IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", 
        "Bracing", 
        "Chilly", 
        "Cool", 
        "Mild", 
        "Warm", 
        "Balmy", 
        "Hot", 
        "Sweltering", 
        "Scorching"
    };

    public async Task<IEnumerable<WeatherForecast>> Handle(
        GetWeatherRequest request, 
        CancellationToken cancellationToken)
    {
        await Task.Delay(50, cancellationToken); // fake delay
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(0, Summaries.Length)]
        }).ToArray();
    }
}
