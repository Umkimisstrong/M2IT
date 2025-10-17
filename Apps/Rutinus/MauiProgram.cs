using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace Rutinus
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureLifecycleEvents(events => 
                {
#if WINDOWS
                    events.AddWindows(windows=>
                    {
                        windows.OnWindowCreated(window=>
                        {
                            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
                            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

                            appWindow.Resize(new Windows.Graphics.SizeInt32(500,800));
                        });
                    });
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                ;

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
