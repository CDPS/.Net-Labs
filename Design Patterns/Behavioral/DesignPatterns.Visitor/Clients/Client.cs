using DesignPatterns.Visitor.Visitors;

namespace DesignPatterns.Visitor.Clients
{
    public abstract class Client
    {
        private string name { get; set; }
        private string address { get; set; }
        private string number { get; set; }
        
        public abstract void Accept(IVisitor visitor);
    }
}
