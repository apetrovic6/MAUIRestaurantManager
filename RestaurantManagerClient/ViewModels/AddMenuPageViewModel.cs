using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class AddMenuPageViewModel : ObservableObject
{
    private RestaurantService RestaurantService { get; set; }
    private MenuService MenuService { get; set; }
    
    [ObservableProperty]
    private List<Restaurant> _restaurants;

    
    
    public string NewName { get; set; }

    [ObservableProperty] private Restaurant _selectedRestaurant = new();
    
    public AddMenuPageViewModel(RestaurantService restaurantService, MenuService menuService)
    {
        RestaurantService = restaurantService;
        MenuService = menuService;
        
        GetRestaurants();
    }

    private  void GetRestaurants()
    { 
      Restaurants = RestaurantService.GetAllRestaurants();
    }
    
    [RelayCommand]
    private async void AddNewMenu()
    {
        var lastPage = Shell.Current.Navigation.NavigationStack.LastOrDefault();
        
        MenuService.AddNewMenu(NewName, SelectedRestaurant.Id);
         Shell.Current.Navigation.RemovePage(lastPage);
         await Shell.Current.GoToAsync("MenuPage");
    }
}