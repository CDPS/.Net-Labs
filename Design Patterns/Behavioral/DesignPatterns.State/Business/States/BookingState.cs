using DesignPatterns.State.Business.Contexts;

namespace DesignPatterns.State.Business.States
{
    public abstract class BookingState
    {
        public abstract void EnterState(Booking booking);
        public abstract void Cancel(Booking booking);
        public abstract void DatePassed(Booking booking);
        public abstract void EnterDetails(Booking booking, string attendee, int ticketCount);
    }
}
