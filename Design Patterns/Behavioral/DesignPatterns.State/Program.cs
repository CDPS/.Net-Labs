using DesignPatterns.State.Business.Contexts;
using System;

namespace DesignPatterns.State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Booking bookingContext = new Booking();

            bookingContext.Cancel();

            bookingContext = new Booking();
            bookingContext.DatePassed();


            bookingContext = new Booking();
            bookingContext.SubmitDetails("test", 1023);

            Console.Read();
        }
    }
}
