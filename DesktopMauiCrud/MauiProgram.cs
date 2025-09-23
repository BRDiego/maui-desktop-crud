using DesktopMauiCrud.MauiCrud.Data.DAOs;
using DesktopMauiCrud.MauiCrud.Data.Imps;
using DesktopMauiCrud.MauiCrud.Data.Interface;
using DesktopMauiCrud.MauiCrud.Data.Interface.UseCase;
using DesktopMauiCrud.MauiCrud.Services;
using DesktopMauiCrud.MauiCrud.ViewModels;
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
            builder.Services.AddSingleton<IClientDAO, ClientDAO>();
            builder.Services.AddSingleton<ClientService>();
            builder.Services.AddScoped<ClientListViewModel>();

            return builder.Build();
        }
    }
}
