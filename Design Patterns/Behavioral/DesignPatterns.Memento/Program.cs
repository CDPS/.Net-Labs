using System;

namespace DesignPatterns.Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor();
            editor.Write("Like and");
            editor.Write("Like and Subscribe");
            editor.Write("Like and subscribe to Geekific !");

            editor.Undo();
        }
    }
}
