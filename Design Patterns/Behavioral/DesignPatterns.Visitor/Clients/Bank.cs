using DesignPatterns.Visitor.Visitors;

namespace DesignPatterns.Visitor.Clients
{
    public class Bank : Client
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitBank(this);
        }
    }
}
