using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class RestaurantViewModel : ObservableObject
{
    private RestaurantService RestaurantService { get; set; }

    [ObservableProperty]
    private List<Restaurant> _restaurants;

    public Restaurant SelectedRestaurant { get; set; } = new();



    public RestaurantViewModel(RestaurantService restaurantService)
    {
        RestaurantService = restaurantService;
        GetRestaurants();
    }
    
    public  void GetRestaurants()
    {
        Restaurants = RestaurantService.GetAllRestaurants();
    }

    [RelayCommand]
    private void Refresh()
    {
        Restaurants = RestaurantService.GetAllRestaurants();
    }

    [RelayCommand]
    private async void GoToRestaurant()
    { 
        var resId = SelectedRestaurant.Oid;
       await Shell.Current.GoToAsync($"Restaurant/Details?resId={resId}", true);
    }

    [RelayCommand]
    private async void GoToCreateRestaurant()
    {
        await Shell.Current.GoToAsync("AddRestaurantPage", true);
    }
    
    [RelayCommand]
    private void UpdateRestaurant(Restaurant restaurant)
    {
        RestaurantService.UpdateRestaurant(restaurant);
        GetRestaurants();
    }
}