using DesignPatterns.Adapter.Adapters;
using DesignPatterns.Adapter.Models;
using DesignPatterns.Adapter.Services;
using System;

namespace DesignPatterns.Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMessageProcessor messageProcessor = new MessageServiceAdapter();
            messageProcessor.DisplayInformation(new XMLMessage() { Name = "Hello World !! " });
        }
    }
}
