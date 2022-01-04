
using System;

namespace DesignPatterns.TemplateMethod.GameLoaders
{
    public class WorldOfWarcraftGameLoader : BaseGameLoader
    {
        public override void CreateObjects(byte[] data)
        {
            Console.WriteLine("Creating WoW Objects...");
        }

        public override void DownloadAddtionalFiles()
        {
            Console.WriteLine("Downloading WoW Sounds...");
        }

        public override void InitializeProfiles()
        {
            Console.WriteLine("Loading WoW profiles...");
        }

        public override byte[] LoadLocalData()
        {
            Console.WriteLine("Loading local WoW files...");
            return new byte[0];
        }
    }
}
