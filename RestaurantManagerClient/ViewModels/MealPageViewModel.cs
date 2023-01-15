using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class MealPageViewModel : ObservableObject
{
    private MealService MealService { get; set; }
    [ObservableProperty] private List<Meal> _meals;

    public MealPageViewModel(MealService mealService)
    {
        MealService = mealService;
    }

    public Meal SelectedMeal { get; set; } = new Meal();
    
    public void GetMeals()
    {
        Meals = MealService.GetAllMeals();
    }

    [RelayCommand]
    private async void GoToAddMeal()
    {
        await Shell.Current.GoToAsync("///MealPage/Add");
    }

    [RelayCommand]
    private async void GoToMeal()
    {
        await Shell.Current.GoToAsync($"///MealPage/Details?mealId={SelectedMeal.Oid}");
    }
}