using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop;

public partial class MenuPageDesktop : ContentPage
{
    public MenuPageDesktop(MenuPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}