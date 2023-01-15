using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Xpo;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

[QueryProperty(nameof(MenuId), "menuId")]
public partial class MenuDetailViewModel : ObservableObject
{
    private int _menuId;
    private MenuService MenuService {get; set; }
    private MealService MealService {get; set; }
    
    [ObservableProperty] 
    private Menu _fetchedMenu;

    [ObservableProperty] private List<Meal> _meals;

    [ObservableProperty]
    private List<object> _selectedMeals = new();
    
    public int MenuId
    {
        get => _menuId;
        set
        {
            if (value == _menuId) return;
            _menuId = value;
            OnPropertyChanged();
            GetMenu();
        }
    }

    public MenuDetailViewModel(MenuService menuService, MealService mealService)
    {
        MenuService = menuService;
        MealService = mealService;
        
        GetMeals();
    }

    private void GetMenu()
    {
        FetchedMenu = MenuService.GetMenuById(MenuId);
    }

    private void GetMeals()
    {
        Meals = MealService.GetAllMeals();
    }
    
    [RelayCommand]
    private async void RemoveMenu()
    {
        MenuService.RemoveMenu(MenuId);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private void AddMealsToMenu()
    {
        var mealList = SelectedMeals.Cast<Meal>().ToList();
        MenuService.UpdateMenu(FetchedMenu, mealList);
        GetMenu();
    }

    [RelayCommand]
    private void RemoveMealFromMenu(Meal meal)
    {
        MenuService.RemoveMeal(MenuId, meal);
        GetMenu();
    }
}