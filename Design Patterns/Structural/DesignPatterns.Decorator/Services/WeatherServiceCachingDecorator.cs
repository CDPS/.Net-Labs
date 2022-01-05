using DesignPatterns.Decorator.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace DesignPatterns.Decorator.Services
{
      public class WeatherServiceCachingDecorator : IWeatherService
      {

            private IMemoryCache _cache;
            private IWeatherService _innerWeatehrService;

            public WeatherServiceCachingDecorator(IWeatherService weatherService, IMemoryCache cache)
            {
                _innerWeatehrService = weatherService;
                _cache = cache;
            }

            public CurrentWeather GetCurrentWeather(string location)
            {
                string cacheKey = $"WeatherConditions::{location}";
                if ( _cache.TryGetValue<CurrentWeather>(cacheKey, out var currentWeather))
                {
                    return currentWeather;
                }
                else
                {
                    var currentConditions = _innerWeatehrService.GetCurrentWeather(location);
                    _cache.Set<CurrentWeather>(cacheKey, currentConditions, TimeSpan.FromMinutes(30));
                    return currentConditions;
                }
            
            }

            public LocationForecast GetForecast(string location)
            {
                string cacheKey = $"WeatherForecast::{location}";
                if (_cache.TryGetValue<LocationForecast>(cacheKey, out var forecast))
                {
                    return forecast;
                }
                else
                {
                    var locationForecast = _innerWeatehrService.GetForecast(location);
                    _cache.Set<LocationForecast>(cacheKey, locationForecast, TimeSpan.FromMinutes(30));
                    return locationForecast;

                }
            }
      }
}
