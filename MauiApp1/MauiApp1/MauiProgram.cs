using MauiApp1.Classes;
using MauiApp1.Provider;
using MauiApp1.ViewModels;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
            builder.Services.AddSingleton(typeof(MainPage));
            builder.Services.AddSingleton(typeof(CalculatorList));
            builder.Services.AddSingleton(typeof(CalculatorProvider));
            builder.Services.AddSingleton(typeof(MainPageViewModel));
            builder.Services.AddTransient(typeof(CalculatorPage));
            builder.Services.AddTransient(typeof(CalculatorViewModel));

            AppLifecycleHandler.Configure(builder);
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}