using DesignPatterns.Adapter.Models;
using DesignPatterns.Adapter.Services;

namespace DesignPatterns.Adapter.Adapters
{
    public class MessageServiceAdapter : IMessageProcessor
    {
        private readonly CustomJsonDisplayer customJsonDisplayer;

        public MessageServiceAdapter()
        {
            this.customJsonDisplayer = new CustomJsonDisplayer();
        }

        public void DisplayInformation(XMLMessage xmlMessage)
        {
            JSONMessage message = ConvertXMLToJson(xmlMessage);
            customJsonDisplayer.Display(message);
        }

        private JSONMessage ConvertXMLToJson(XMLMessage xmlMessage)
        {
            return new JSONMessage
            {
                Name = xmlMessage.Name
            };
        }
    }
}
