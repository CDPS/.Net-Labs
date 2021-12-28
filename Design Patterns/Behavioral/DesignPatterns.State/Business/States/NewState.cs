using DesignPatterns.State.Business.Contexts;
using System;

namespace DesignPatterns.State.Business.States
{
    public class NewState : BookingState
    {
        public override void Cancel(Booking booking)
        {
            booking.TransitionToState(new ClosedState("Booking Canceled"));
        }

        public override void DatePassed(Booking booking)
        {
            booking.TransitionToState(new ClosedState("Booking Expired"));
        }

        public override void EnterDetails(Booking booking, string attendee, int ticketCount)
        {
            booking.Attendee = attendee;
            booking.TicketCount = ticketCount;
            booking.TransitionToState(new PendingState());
        }

        public override void EnterState(Booking booking)
        {
            booking.BookingID = new Random().Next();
            Console.WriteLine("New");
        }
    }
}
