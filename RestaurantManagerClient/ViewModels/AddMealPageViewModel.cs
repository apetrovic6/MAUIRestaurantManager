using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class AddMealPageViewModel : ObservableObject
{
    private MealService MealService { get; set; }
    private RestaurantService RestaurantService { get; set; }
    private MenuService MenuService { get; set; }

    [ObservableProperty] private Meal _newMeal = new();

    [ObservableProperty] private List<Menu> _menus;

    [ObservableProperty] private Menu _selectedMenu = new();

    public AddMealPageViewModel(MealService mealService, RestaurantService restaurantService, MenuService menuService)
    {
        MealService = mealService;
    }

    [RelayCommand]
    private async void AddNewMeal()
    {
        MealService.AddNewMeal(NewMeal);
        await Shell.Current.GoToAsync("..");
    }
}