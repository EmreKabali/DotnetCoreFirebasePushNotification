using System;
using DotnetCoreFirebasePushNotification.Models;

namespace DotnetCoreFirebasePushNotification.Services;

public class FuelRepository : IFuelRepository
{
    protected FirebaseContext _context;
    public FuelRepository(FirebaseContext context)
    {
        _context = context;
    }
    public List<Fuel> GetFuels(string cityName)
    {
        return _context.Set<Fuel>().Where(x => x.City == cityName).ToList();
    }
}
