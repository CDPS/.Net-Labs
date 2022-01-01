using DesignPatterns.ChainOfResponsibility.Models;
using DesignPatterns.ChainOfResponsibility.PaymentProcessors;
using System.Linq;

namespace DesignPatterns.ChainOfResponsibility.Handlers.PaymentHandlers
{
    public class InvoiceHandler : IReceiver<Order>
    {
        private IPaymentProcessor InvoicePaymentProcessor { get; }
            = new InvoicePaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
            {
                InvoicePaymentProcessor.Finalize(order);
            }
        }
    }
}
