
using DesignPatterns.Decorator.Entities;

namespace DesignPatterns.Decorator.Services
{
    public interface IWeatherService
    {
        CurrentWeather GetCurrentWeather(string location);
        LocationForecast GetForecast(string location);
    }
}
