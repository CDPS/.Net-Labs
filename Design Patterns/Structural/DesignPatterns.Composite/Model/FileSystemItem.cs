
namespace DesignPatterns.Composite.Model
{
    public abstract class FileSystemItem
    {
        public FileSystemItem(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract decimal GetSizeInKB();

        public abstract void Print(int depth);
    }
}
