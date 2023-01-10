using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class RestaurantViewModel : ObservableObject
{
    private RestaurantService RestaurantService { get; set; }
    
    [ObservableProperty] 
    private Restaurant _newRestaurant = new();
    
    [ObservableProperty]
    private List<Restaurant> _restaurants;


    
    public RestaurantViewModel(RestaurantService restaurantService)
    {
        RestaurantService = restaurantService;
        GetRestaurants();
    }
    
    private  void GetRestaurants()
    {
        Restaurants = RestaurantService.GetAllRestaurants();
    }
    
    [RelayCommand]
    private void AddNewRestaurant()
    {
        RestaurantService.AddNewRestaurant(NewRestaurant);
        GetRestaurants();
    }

    [RelayCommand]
    private void DeleteRestaurant(string id)
    {
        RestaurantService.RemoveRestaurant(id);
        GetRestaurants();
    }

    [RelayCommand]
    private void UpdateRestaurant(Restaurant restaurant)
    {
        RestaurantService.UpdateRestaurant(restaurant);
        GetRestaurants();
    }
}