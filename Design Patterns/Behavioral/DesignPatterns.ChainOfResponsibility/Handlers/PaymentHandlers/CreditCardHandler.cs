using DesignPatterns.ChainOfResponsibility.Models;
using DesignPatterns.ChainOfResponsibility.PaymentProcessors;
using System.Linq;

namespace DesignPatterns.ChainOfResponsibility.Handlers.PaymentHandlers
{
    public class CreditCardHandler : IReceiver<Order>
    {
        private IPaymentProcessor CreditCardPaymentProcessor { get; }
            = new CreditCardPaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
            {
                CreditCardPaymentProcessor.Finalize(order);
            }
        }
    }
}
