using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop.MealsPages;

public partial class AddMealPageDesktop : ContentPage
{
    public AddMealPageDesktop(AddMealPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}