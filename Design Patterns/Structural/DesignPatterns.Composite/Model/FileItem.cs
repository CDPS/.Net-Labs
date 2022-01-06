
using System;

namespace DesignPatterns.Composite.Model
{
    public class FileItem : FileSystemItem
    {
        public FileItem(string name, long fileBytes) : base(name)
        {
            this.FileBytes = fileBytes;
        }

        public long FileBytes { get; }

        public override decimal GetSizeInKB()
        {
            return decimal.Divide(this.FileBytes, 1000);
        }

        public override void Print(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.Name);
        }
    }
}
