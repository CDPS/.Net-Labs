using System.Collections.Generic;

namespace DesignPatterns.Memento
{
    public class Editor
    {
        private Stack<Memento> stateHistory;
        private TextArea textArea;

        public Editor()
        {
            stateHistory = new Stack<Memento>();
            textArea = new TextArea();
        }

        public void Write(string text)
        {
            textArea.set(text);
            stateHistory.Push(textArea.TakeSnapshot()); 
        }

        public void Undo()
        {
            textArea.Restore(stateHistory.Pop());
        }
    }
}
