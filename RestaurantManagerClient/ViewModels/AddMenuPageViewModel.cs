using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Xpo;
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

    [ObservableProperty] private Restaurant _selectedRestaurant;
    
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
        MenuService.AddNewMenu(NewName, SelectedRestaurant.Oid);
         await Shell.Current.GoToAsync("..");
    }
}