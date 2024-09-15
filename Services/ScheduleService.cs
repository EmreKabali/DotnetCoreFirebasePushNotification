using System;
using Hangfire;

namespace DotnetCoreFirebasePushNotification.Services;

public class ScheduleService : IScheduleService
{
    public void RunTasks()
    {
        SendFuelPrices();
    }

    [Queue("reminder")]
    [AutomaticRetry(Attempts = 0)]
    [JobDisplayName("SendFuelPrices")]
    private void SendFuelPrices()
    {
        RecurringJob.AddOrUpdate<IPushNotificationService>(x => x.SendFuelPrices(), "0 12 * * *");
    }
}
