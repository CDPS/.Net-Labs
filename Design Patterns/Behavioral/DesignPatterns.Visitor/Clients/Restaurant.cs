using DesignPatterns.Visitor.Visitors;

namespace DesignPatterns.Visitor.Clients
{
    public class Restaurant : Client
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitRestaurant(this);
        }
    }
}
