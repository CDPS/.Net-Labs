using DesignPatterns.Visitor.Clients;
using DesignPatterns.Visitor.ObjectsStructures;
using DesignPatterns.Visitor.Visitors;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>
            {
                new Bank(),
                new Company(),
                new Restaurant(),
                new Resident(),
            };

            var messagingService = new ClientObjectStructure(clients);
            messagingService.ApplyVisitor(new InsuranceMessagingVisitor());

        }
    }
}
