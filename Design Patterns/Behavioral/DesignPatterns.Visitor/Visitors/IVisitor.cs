using DesignPatterns.Visitor.Clients;

namespace DesignPatterns.Visitor.Visitors
{
    public interface IVisitor
    {
        public void VisitBank(Bank bank);
        public void VisitCompany(Company company);
        public void VisitResident(Resident resident); 
        public void VisitRestaurant(Restaurant restaurant);
    }
}
