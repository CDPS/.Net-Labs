using DesignPatterns.Visitor.Visitors;

namespace DesignPatterns.Visitor.Clients
{
    public class Company : Client
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCompany(this);
        }
    }
}
