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
                               .OnResume(activity => ShowToast("Velkommen tilbage"))  
                               .OnCreate((activity, bundle) => ShowToast("Velkommen")));  
#elif IOS
                           events.AddiOS(ios => ios  
                               .OnActivated(app => ShowToast("Velkommen tilbage"))  
                               .FinishedLaunching((app, options) => { ShowToast("Velkommen"); return true; }));  
#elif WINDOWS
                events.AddWindows(windows => windows
                    .OnActivated((window, args) => ShowToast("Velkommen tilbage"))
                    .OnLaunched((app, args) => ShowToast("Velkommen")));
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
