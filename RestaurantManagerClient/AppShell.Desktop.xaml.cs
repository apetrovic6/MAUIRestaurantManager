using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.Views.Desktop;
using RestaurantManagerClient.Views.Desktop.MealsPages;
using RestaurantManagerClient.Views.Desktop.MenuPages;
using RestaurantManagerClient.Views.Desktop.RestaurantPages;

namespace RestaurantManagerClient;

public partial class AppShellDesktop : Shell
{
    public AppShellDesktop()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("MainPage", typeof(MainPageDesktop));
        Routing.RegisterRoute("MenuPage", typeof(MenuPageDesktop));
        Routing.RegisterRoute("MenuPage/Add", typeof(AddMenuPageDesktop));
        Routing.RegisterRoute("RestaurantPage", typeof(RestaurantPage));
        Routing.RegisterRoute("Restaurant/Details", typeof(RestaurantDetailPageDesktop));
        Routing.RegisterRoute("RestaurantPage/Add", typeof(AddRestaurantPageDesktop));
        Routing.RegisterRoute("MenuDetailPage", typeof(MenuDetailPageDesktop));
        Routing.RegisterRoute("MealPage", typeof(MealPageDesktop));
        Routing.RegisterRoute("MealPage/Details", typeof(MealDetailPageDesktop));
        Routing.RegisterRoute("MealPage/Add", typeof(AddMealPageDesktop));
    }
}