using DesignPatterns.Visitor.Clients;
using DesignPatterns.Visitor.Visitors;
using System.Collections.Generic;

namespace DesignPatterns.Visitor.ObjectsStructures
{
    public class ClientObjectStructure
    {
        private List<Client> _clients;

        public ClientObjectStructure(List<Client> clients)
        {
            _clients = clients;
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            foreach (var client in _clients)
            {
                client.Accept(visitor);
            }
        }
    } 
}
