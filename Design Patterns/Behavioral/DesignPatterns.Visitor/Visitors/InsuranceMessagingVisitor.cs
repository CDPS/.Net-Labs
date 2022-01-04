using DesignPatterns.Visitor.Clients;
using System;

namespace DesignPatterns.Visitor.Visitors
{
    public class InsuranceMessagingVisitor : IVisitor
    {
        public void VisitBank(Bank bank)
        {
            Console.WriteLine("Sending mail about theft insurance...");
        }

        public void VisitCompany(Company company)
        {
            Console.WriteLine("Sending employees and equipment insurance mail...");
        }

        public void VisitResident(Resident resident)
        {
            Console.WriteLine("Sending mail about medical insurace...");
        }

        public void VisitRestaurant(Restaurant restaurant)
        {
            Console.WriteLine("Sending mail about fire and food insurance...");
        }
    }
}
