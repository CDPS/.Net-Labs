using DesignPatterns.State.Business.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.State.Business.Config
{
    public enum ProcessingResult { Sucess, Fail, Cancel }
    public class StaticFunctions
    {
        public static async void ProcessBooking(Contexts.Booking booking, Action<Contexts.Booking, ProcessingResult> callback, CancellationTokenSource token)
        {

            try
            {
                await Task.Run(async delegate
                {
                    await Task.Delay(new TimeSpan(0, 0, 3), token.Token);
                });
            }
            catch (OperationCanceledException)
            {
                callback(booking, ProcessingResult.Cancel);
                return;
            }

            ProcessingResult result = new Random().Next(0, 2) == 0 ? ProcessingResult.Sucess : ProcessingResult.Fail;
            callback(booking, result);
        }
    }
}
