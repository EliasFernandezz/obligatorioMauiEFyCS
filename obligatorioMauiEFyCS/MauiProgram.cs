using Microsoft.Extensions.Logging;
using obligatorioMauiEFyCS.Service;
using CommunityToolkit.Maui;

namespace obligatorioMauiEFyCS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
            {
                builder.UseMauiMaps();
            }

            builder.Services.AddSingleton<AuthService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
