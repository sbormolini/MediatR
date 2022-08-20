using MediatR;
using MediatRDemo.Models;

namespace MediatRDemo.Handlers;

public class WeatherWarningHandler : INotificationHandler<WeatherWarningNotification>
{
    public async Task Handle(WeatherWarningNotification notification, CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        Console.WriteLine("Console output from WeatherWarningHandler");
    }
}
