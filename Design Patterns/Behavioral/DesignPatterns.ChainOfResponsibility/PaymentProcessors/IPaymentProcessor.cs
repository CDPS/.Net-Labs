using DesignPatterns.ChainOfResponsibility.Models;

namespace DesignPatterns.ChainOfResponsibility.PaymentProcessors
{
    public interface IPaymentProcessor
    {
        void Finalize(Order order);
    }
}
