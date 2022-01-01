using DesignPatterns.ChainOfResponsibility.Models;
using DesignPatterns.ChainOfResponsibility.PaymentProcessors;
using System.Linq;

namespace DesignPatterns.ChainOfResponsibility.Handlers.PaymentHandlers
{
    public class PaypalHandler : IReceiver<Order>
    {
        private IPaymentProcessor PaypalPaymentProcessor { get; }
            = new PaypalPaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Paypal))
            {
                PaypalPaymentProcessor.Finalize(order);
            }
        }
    }
}
