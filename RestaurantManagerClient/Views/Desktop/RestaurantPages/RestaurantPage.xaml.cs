using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop.RestaurantPages;

public partial class RestaurantPage : ContentPage
{
    public RestaurantPage(RestaurantViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}