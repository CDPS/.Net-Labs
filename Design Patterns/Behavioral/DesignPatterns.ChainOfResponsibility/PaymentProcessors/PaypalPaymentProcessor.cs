﻿using DesignPatterns.ChainOfResponsibility.Models;
using System.Linq;

namespace DesignPatterns.ChainOfResponsibility.PaymentProcessors
{
    public class PaypalPaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order order)
        {
            // Invoke the Paypal API to finalize payment

            var payment = order.SelectedPayments
                .FirstOrDefault(x => x.PaymentProvider == PaymentProvider.Paypal);

            if (payment == null) return;

            order.FinalizedPayments.Add(payment);
        }
    }
}
