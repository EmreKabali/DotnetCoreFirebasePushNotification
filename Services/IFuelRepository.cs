using System;
using DotnetCoreFirebasePushNotification.Models;

namespace DotnetCoreFirebasePushNotification.Services;

public interface IFuelRepository
{
    List<Fuel> GetFuels(string cityName);
}
