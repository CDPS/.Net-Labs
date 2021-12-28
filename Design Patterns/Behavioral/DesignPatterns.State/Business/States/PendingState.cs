using System;
using System.Threading;
using DesignPatterns.State.Business.Config;
using DesignPatterns.State.Business.Contexts;

namespace DesignPatterns.State.Business.States
{
    public class PendingState : BookingState
    {
        private CancellationTokenSource cancelToken;

        public override void Cancel(Booking booking)
        {
            cancelToken.Cancel();
        }

        public override void DatePassed(Booking booking) =>  throw new NotImplementedException();
        
        public override void EnterDetails(Booking booking, string attendee, int ticketCount) => throw new NotImplementedException();
        
        public override void EnterState(Booking booking)
        {
            cancelToken = new CancellationTokenSource();

            Console.WriteLine("Pending");
            Console.WriteLine("Processing Booking");
            StaticFunctions.ProcessBooking(booking, ProcessingComplete, cancelToken);
        }

        public void ProcessingComplete(Booking booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing Canceled"));
                    break;
            }
        }
    }
}
