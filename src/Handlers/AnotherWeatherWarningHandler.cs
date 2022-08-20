using MediatR;
using MediatRDemo.Models;

namespace MediatRDemo.Handlers;

public class AnotherWeatherWarningHandler : INotificationHandler<WeatherWarningNotification>
{
    public async Task Handle(WeatherWarningNotification notification, CancellationToken cancellationToken)
    {
        await Task.Delay(2000, cancellationToken);
        Console.WriteLine("Console output from AnotherWeatherWarningHandler");
    }
}
