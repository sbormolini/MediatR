using MediatR;

namespace MediatRDemo.Models;

public class WeatherWarningNotification : INotification
{
    public string Message { get; }

    public WeatherWarningNotification(string message)
    {
        Message = message;
    }
} 