using System;

namespace DesingPatterns.Singleton
{
    public sealed class Singleton
    {
        // reading this will initialize the instance
        public static readonly Lazy<Singleton> _lazy = new Lazy<Singleton>(() => new Singleton());
        public string Id { get; set; }
        public static Singleton Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        private Singleton()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
