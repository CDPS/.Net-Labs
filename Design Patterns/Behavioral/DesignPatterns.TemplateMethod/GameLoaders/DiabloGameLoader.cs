
using System;

namespace DesignPatterns.TemplateMethod.GameLoaders
{
    public class DiabloGameLoader : BaseGameLoader
    {
        public override void CreateObjects(byte[] data)
        {
            Console.WriteLine("Creating Diablo Objects...");
        }

        public override void DownloadAddtionalFiles()
        {
            Console.WriteLine("Downloading Diablo Sounds...");
        }

        public override void InitializeProfiles()
        {
            Console.WriteLine("Loading Diablo profiles...");
        }

        public override byte[] LoadLocalData()
        {
            Console.WriteLine("Loading Diablo WoW files...");
            return new byte[0];
        }
    }
}
