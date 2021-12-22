using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPatterns.Strategy.Configuration
{

    public enum ShippingStatus
    {
        WaitingForPayment,
        ReadyForShippment,
        Shipped
    }

    public enum PaymentProvider
    {
        Paypal,
        CreditCard,
        Invoice
    }

    public enum ItemType
    {
        Service,
        Food,
        Hardware,
        Literature
    }
}
