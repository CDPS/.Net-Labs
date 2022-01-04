using DesignPatterns.TemplateMethod.GameLoaders;
using System;

namespace DesignPatterns.TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseGameLoader gameLoader = new WorldOfWarcraftGameLoader();
            gameLoader.Load();


            gameLoader = new DiabloGameLoader();
            gameLoader.Load();
        }
    }
}
