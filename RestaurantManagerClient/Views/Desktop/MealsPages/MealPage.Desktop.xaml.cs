using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop.MealsPages;

public partial class MealPageDesktop : ContentPage
{
    public MealPageDesktop(MealPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    
        var vm = (MealPageViewModel)BindingContext;
    
        vm.GetMeals();
    }
}