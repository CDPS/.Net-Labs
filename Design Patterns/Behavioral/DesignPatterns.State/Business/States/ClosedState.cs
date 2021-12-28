using DesignPatterns.State.Business.Contexts;
using System;

namespace DesignPatterns.State.Business.States
{
    public class ClosedState : BookingState
    {
        private string reasonClosed;

        public ClosedState(string reason)
        {
            reasonClosed = reason;
        }

        public override void Cancel(Booking booking)
        {
            Console.WriteLine("Invalid action for this state", "Closed Booking Error");
        }

        public override void DatePassed(Booking booking)
        {
            Console.WriteLine("Invalid action for this state", "Closed Booking Error");
        }

        public override void EnterDetails(Booking booking, string attendee, int ticketCount)
        {
            Console.WriteLine("Invalid action for this state", "Closed Booking Error");
        }

        public override void EnterState(Booking booking)
        {
            Console.WriteLine("Closed");
            Console.WriteLine(reasonClosed);
        }
    }
}
