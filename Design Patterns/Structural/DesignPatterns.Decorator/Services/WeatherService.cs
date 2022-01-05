using DesignPatterns.Decorator.Entities;

namespace DesignPatterns.Decorator.Services
{
    public class WeatherService : IWeatherService
    {
        public CurrentWeather GetCurrentWeather(string location)
        {
            // http request to get CurrentWather
            return new CurrentWeather() { Success = false, ErrorMessage = $"Weather data for {location} could not be found" };
        }

        public LocationForecast GetForecast(string location)
        {
            // http request to get LocationForeCast
            return new LocationForecast() { Success = false, ErrorMessage = $"Forecast data for {location} could not be found" };
        }
    }
}
