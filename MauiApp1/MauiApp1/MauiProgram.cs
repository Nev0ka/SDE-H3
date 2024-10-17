using MauiApp1.Classes;
using MauiApp1.Provider;
using MauiApp1.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(typeof(MainPage));
            builder.Services.AddSingleton(typeof(CalculatorProvider));
            builder.Services.AddSingleton(typeof(MainPageViewModel));
            builder.Services.AddSingleton(typeof(CalculatorPage));
            builder.Services.AddSingleton(typeof(CalculatorViewModel));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}