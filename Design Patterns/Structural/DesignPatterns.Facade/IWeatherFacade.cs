using DesignPatterns.Facade.Entities;

namespace DesignPatterns.Facade
{
    public interface IWeatherFacade
    {
        WeatherFacadeResults GetTempInCity(string zipCode);
    }
}