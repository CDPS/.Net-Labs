using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Memento
{
    public class TextArea
    {
        private string text;
        
        public void set(string text)
        {
            this.text = text;
        }

        internal Memento TakeSnapshot()
        {
            return new Memento(this.text);
        }

        internal void Restore(Memento memento)
        {
            this.text = memento.GetSavedText();
        }
    }
}
