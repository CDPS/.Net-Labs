namespace DesingPatterns.Prototype.Models
{
    public abstract class Prototype
    {
        public abstract Prototype ShallowClone();
        public abstract Prototype DeepClone();
    }
}
