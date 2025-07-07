using Microsoft.Extensions.Logging;
using ReserveParkingSpace_Mobile_.Controllers;
using ReserveParkingSpace_Mobile_.Controllers.IControllers;
using ReserveParkingSpace_Mobile_.Services;
using ReserveParkingSpace_Mobile_.Services.IServices;
using Syncfusion.Maui.Core.Hosting;

namespace ReserveParkingSpace_Mobile_
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                });

            builder.Services.AddScoped<IDataService, DataService>();
            builder.Services.AddScoped<IMainPageController, MainPageController>();
            builder.Services.AddHttpClient();
            // Registers HttpClient + your service
            builder.Services.AddLogging();                 // Optional, usually already there

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
