
namespace DesingPatterns.SimpleFactory.Business.Configuration
{
    public enum ShippingType
    {
        Standard,
        Express,
        NextDay
    }

    public enum ShippingStatus
    {
        WaitingForPayment,
        ReadyForShippment,
        Shipped
    }
}
