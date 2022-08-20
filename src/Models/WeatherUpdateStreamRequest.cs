using MediatR;

namespace MediatRDemo.Models;

public class WeatherUpdateStreamRequest : IStreamRequest<WeatherForecast>
{
	public string City { get; }

	public WeatherUpdateStreamRequest(string city)
	{
		City = city;	
	}
}
