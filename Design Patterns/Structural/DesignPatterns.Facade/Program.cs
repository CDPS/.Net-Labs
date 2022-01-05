using DesignPatterns.Facade.Entities;
using System;

namespace DesignPatterns.Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string zipCode = "98074";

            IWeatherFacade weatherFacade = new WeatherFacade();
            WeatherFacadeResults results = weatherFacade.GetTempInCity(zipCode);

            Console.WriteLine("The current temperature is {0}F/{1}C in {2}, {3}",
                                results.Fahrenheit,
                                results.Celsius,
                                results.City.Name,
                                results.State.Name);
        }
    }
}
