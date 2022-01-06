

using DesignPatterns.Adapter.Models;
using System;

namespace DesignPatterns.Adapter.Services
{
    public class CustomJsonDisplayer
    {
        public void Display(JSONMessage jsonMessage)
        {
            Console.WriteLine($"JSON Object With NAME {jsonMessage.Name}");
        }
    }
}
