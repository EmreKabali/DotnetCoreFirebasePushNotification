using System;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreFirebasePushNotification.Models;

public class FirebaseContext : DbContext
{

    //database connections info will come base program cs 
    public FirebaseContext(DbContextOptions<FirebaseContext> options) : base(options)
    {

    }


    public DbSet<Fuel> Fuels { get; }


}
