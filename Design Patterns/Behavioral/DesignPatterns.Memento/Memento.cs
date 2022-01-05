
namespace DesignPatterns.Memento
{
    internal sealed class Memento
    {
        private string text;

        internal Memento(string textToSave)
        {
            text = textToSave;
        }

        internal string GetSavedText()
        {
            return text;
        }
    }
}
