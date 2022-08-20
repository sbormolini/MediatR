using MediatR;

namespace MediatRDemo.Models;

public class GetWeatherRequest : IRequest<IEnumerable<WeatherForecast>>
{
    public string City { get; }

    public GetWeatherRequest(string city)
    {
        City = city;
    }
}