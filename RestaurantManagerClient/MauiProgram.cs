using CommunityToolkit.Maui;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.Extensions.Logging;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Repositories;
using RestaurantManagerClient.Services;
using RestaurantManagerClient.ViewModels;
using RestaurantManagerClient.Views.Desktop;
using RestaurantManagerClient.Views.Desktop.MealsPages;
using RestaurantManagerClient.Views.Desktop.MenuPages;
using RestaurantManagerClient.Views.Desktop.RestaurantPages;
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
        builder.Services.AddSingleton<Repository<Menu>>();
        builder.Services.AddSingleton<Repository<Meal>>();
        
        builder.Services.AddSingleton<RestaurantService>();
        builder.Services.AddSingleton<MenuService>();
        builder.Services.AddSingleton<MealService>();
        
        builder.Services.AddSingleton<MainPageDesktop>();
        builder.Services.AddSingleton<MainPageMobile>();
        builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddTransient<MenuPageViewModel>();
        builder.Services.AddTransient<MenuPageDesktop>();

        builder.Services.AddTransient<RestaurantPage>();
        builder.Services.AddTransient<RestaurantViewModel>();
        builder.Services.AddTransient<AddMenuPageDesktop>();
        builder.Services.AddTransient <AddMenuPageViewModel>();

        builder.Services.AddScoped<RestaurantDetailPageDesktop>();
        builder.Services.AddScoped<RestaurantDetailViewModel>();

        builder.Services.AddTransient<MenuDetailPageDesktop>();
        builder.Services.AddTransient<MenuDetailViewModel>();

        builder.Services.AddTransient<AddRestaurantPageDesktop>();
        builder.Services.AddTransient<AddNewRestaurantViewModel>();

        builder.Services.AddTransient<MealPageDesktop>();
        builder.Services.AddTransient<MealPageViewModel>();
        
        builder.Services.AddTransient<AddMealPageDesktop>();
        builder.Services.AddTransient<AddMealPageViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}