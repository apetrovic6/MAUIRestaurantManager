using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop.RestaurantPages;

public partial class AddRestaurantPageDesktop : ContentPage
{
    public AddRestaurantPageDesktop(AddNewRestaurantViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}