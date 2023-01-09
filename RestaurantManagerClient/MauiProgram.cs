using CommunityToolkit.Maui;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.Extensions.Logging;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}