using CommunityToolkit.Mvvm.ComponentModel;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

[QueryProperty(nameof(MealId), "menuId")]
public partial class MealDetailPageViewModel : ObservableObject
{
    private int _mealId;
    private MealService MealService { get; set; }

    public int MealId
    {
        get => _mealId;
        set
        {
            if (value == _mealId) return;
            _mealId = value;
            OnPropertyChanged();
            GetMeal();
        }
    }

    [ObservableProperty] private Meal _fetchedMeal;
    
    public MealDetailPageViewModel(MealService mealService)
    {
        MealService = mealService;
    }

    private void GetMeal()
    {
        FetchedMeal = MealService.GetMealById(MealId);
    }
}