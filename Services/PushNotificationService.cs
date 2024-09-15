using System;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace DotnetCoreFirebasePushNotification.Services;

public class PushNotificationService : IPushNotificationService
{
    private IFuelRepository _fuelRepository;

    public PushNotificationService(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }
    public async Task SendFuelPrices()
    {
        var fuels = _fuelRepository.GetFuels("Istanbul");
        if (fuels != null && fuels.Count > 0)
        {
            //sending firebase message.
            FirebaseApp firebaseApp;
            var credential = GoogleCredential.FromFile("firebasefile.json");
            //check instance control here
            if (FirebaseApp.DefaultInstance == null)
            {
                firebaseApp = FirebaseApp.Create(new AppOptions
                {
                    Credential = credential,
                });
            }
            else
            {
                firebaseApp = FirebaseApp.DefaultInstance;
            }
            var messaging = FirebaseMessaging.GetMessaging(firebaseApp);
            // Create a new Message object
            var message = new Message()
            {
                Topic = "generaltopic",
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = fuels[0].City,
                    Body = fuels[0].Name + " " + fuels[0].Price
                },

            };
            string result = await messaging.SendAsync(message);
        }
    }
}
