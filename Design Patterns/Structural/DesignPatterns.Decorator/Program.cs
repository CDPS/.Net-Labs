using DesignPatterns.Decorator.Services;
using Microsoft.Extensions.Caching.Memory;

namespace DesignPatterns.Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWeatherService concreteService = new WeatherService();
            IWeatherService withCachingDecorator = new WeatherServiceCachingDecorator(concreteService, new MemoryCache(new MemoryCacheOptions()));
            IWeatherService withLoggingDecorator = new WeatherServiceLoggingDecorator(withCachingDecorator);

            withLoggingDecorator.GetCurrentWeather("Los Angeles");
        }
    }
}
