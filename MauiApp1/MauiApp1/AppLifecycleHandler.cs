using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.LifecycleEvents;

namespace MauiApp1
{
    public static class AppLifecycleHandler
    {
        public static void Configure(MauiAppBuilder appBuilder)
        {
            appBuilder.ConfigureLifecycleEvents(static events =>
            {
#if ANDROID
                           events.AddAndroid(android => android  
                               .OnResume(activity => ShowToast("Welcome back!"))  
                               .OnCreate((activity, bundle) => ShowToast("App opened!")));  
#elif IOS
                           events.AddiOS(ios => ios  
                               .OnActivated(app => ShowToast("Welcome back!"))  
                               .FinishedLaunching((app, options) => { ShowToast("App opened!"); return true; }));  
#elif WINDOWS
                events.AddWindows(windows => windows
                    .OnActivated((window, args) => ShowToast("Welcome back!"))
                    .OnLaunched((app, args) => ShowToast("App opened!")));
#endif
            });
        }

        private static void ShowToast(string message)
        {
            var toast = Toast.Make(message, ToastDuration.Short, 12);
            toast.Show();
        }
    }
}
