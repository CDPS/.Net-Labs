using DesignPatterns.Adapter.Models;

namespace DesignPatterns.Adapter.Services
{
    public interface IMessageProcessor
    {
        void DisplayInformation(XMLMessage xMLObject);
    }
}
