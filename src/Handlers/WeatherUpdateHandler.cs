using MediatR;
using MediatRDemo.Models;
using System;
using System.Runtime.CompilerServices;

namespace MediatRDemo.Handlers;

public class WeatherUpdateHandler : IStreamRequestHandler<WeatherUpdateStreamRequest, WeatherForecast>
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

    public async IAsyncEnumerable<WeatherForecast> Handle(
        WeatherUpdateStreamRequest request, 
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested is false)
        {
            await Task.Delay(500, cancellationToken);
            yield return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}
