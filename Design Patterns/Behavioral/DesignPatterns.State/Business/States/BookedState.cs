using DesignPatterns.State.Business.Contexts;
using System;

namespace DesignPatterns.State.Business.States
{
    public class BookedState : BookingState
    {
        public override void Cancel(Booking booking)
        {
            booking.TransitionToState(new ClosedState("Booking canceled: Expect a refund"));
        }

        public override void DatePassed(Booking booking)
        {
            booking.TransitionToState(new ClosedState("We hope you enjoyed the event!"));
        }

        public override void EnterDetails(Booking booking, string attendee, int ticketCount) => throw new NotImplementedException();
        
        public override void EnterState(Booking booking)
        {
            Console.WriteLine("Booked");
            Console.WriteLine("Enjoy the Event");
        }
    }
}
