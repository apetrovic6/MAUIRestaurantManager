using CommunityToolkit.Maui;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.Extensions.Logging;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Repositories;
using RestaurantManagerClient.Services;
using RestaurantManagerClient.ViewModels;
using RestaurantManagerClient.Views.Desktop;
using RestaurantManagerClient.Views.Mobile;

namespace RestaurantManagerClient;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "RestaurantManagerDB.db3");
        string connectionString = SQLiteConnectionProvider.GetConnectionString($"{dbPath};Cache=Shared");
        XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
        
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<Repository<Restaurant>>();
        builder.Services.AddSingleton<RestaurantService>();
        
        builder.Services.AddSingleton<MainPageDesktop>();
        builder.Services.AddSingleton<MainPageMobile>();
        builder.Services.AddSingleton<MainPageViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}