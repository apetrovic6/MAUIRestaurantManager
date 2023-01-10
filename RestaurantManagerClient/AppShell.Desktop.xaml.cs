using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.Views.Desktop;

namespace RestaurantManagerClient;

public partial class AppShellDesktop : Shell
{
    public AppShellDesktop()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("MainPage", typeof(MainPageDesktop));
        Routing.RegisterRoute("MenuPage", typeof(MenuPageDesktop));
    }
}