using DesignPatterns.Visitor.Visitors;

namespace DesignPatterns.Visitor.Clients
{
    public class Resident : Client
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitResident(this);
        }
    }
}
