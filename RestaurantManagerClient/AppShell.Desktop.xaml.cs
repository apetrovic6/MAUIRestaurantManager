using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.Views.Desktop;
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
        Routing.RegisterRoute("AddMenuPage", typeof(AddMenuPageDesktop));
        
        Routing.RegisterRoute("RestaurantPage", typeof(RestaurantPage));
    }
}