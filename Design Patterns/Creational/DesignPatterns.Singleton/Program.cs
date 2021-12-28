using System;

namespace DesingPatterns.Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Singleton.Instance;
            Console.WriteLine(result.Id);
        }
    }
}
