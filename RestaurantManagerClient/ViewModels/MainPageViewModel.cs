using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private RestaurantService RestaurantService { get; set; } 

    [ObservableProperty]
    private List<Restaurant> _restaurants;
    
    public MainPageViewModel(RestaurantService restaurantService)
    {
        RestaurantService = restaurantService;
        GetRestaurants();
    }

    private  void GetRestaurants()
    {
        Restaurants = RestaurantService.GetAllRestaurants();
    }
    
    
}