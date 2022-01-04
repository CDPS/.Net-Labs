using System;

namespace DesignPatterns.TemplateMethod.GameLoaders
{
    public abstract class BaseGameLoader
    {
        public void Load()
        {
            byte[] data = LoadLocalData();
            CreateObjects(data);
            DownloadAddtionalFiles();
            CleanTempFiles();
            InitializeProfiles();
        }

        public abstract byte[] LoadLocalData();
        public abstract void CreateObjects(byte[] data);
        public abstract void DownloadAddtionalFiles();
        public abstract void InitializeProfiles();
    
        protected virtual void CleanTempFiles()
        {
            Console.WriteLine("Cleaning Temporary files...");
            //Some other Code
        }
    }
}
