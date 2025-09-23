using DesktopMauiCrud.MauiCrud.Data.Imps;
using DesktopMauiCrud.MauiCrud.Data.Interface;
using Microsoft.Extensions.Logging;

namespace DesktopMauiCrud
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(typeof(IDataStorage<>), typeof(JsonDataStorage<>));

            return builder.Build();
        }
    }
}
