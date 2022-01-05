using DesignPatterns.Decorator.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatterns.Decorator.Services
{
    public class WeatherServiceLoggingDecorator : IWeatherService
    {

        private IWeatherService _innerWeatherService;

        public WeatherServiceLoggingDecorator(IWeatherService weatherService)
        {
            _innerWeatherService = weatherService;
        }

        public CurrentWeather GetCurrentWeather(string location)
        {
            var sw = Stopwatch.StartNew();
            var currentWeather = _innerWeatherService.GetCurrentWeather(location);
            sw.Stop();
            var elapsedMillis = sw.ElapsedMilliseconds;
            Console.WriteLine("Retrieved weather data for {0} - Elapsed ms: {1} {2}", location, elapsedMillis, currentWeather);

            return currentWeather;
        }

        public LocationForecast GetForecast(string location)
        {
            return _innerWeatherService.GetForecast(location);
        }
    }
}
