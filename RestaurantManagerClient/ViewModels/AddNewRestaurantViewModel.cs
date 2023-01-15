using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class AddNewRestaurantViewModel : ObservableObject
{
    
    private RestaurantService RestaurantService { get; set; }
    
    [ObservableProperty]
    private Restaurant _newRestaurant = new();
    public AddNewRestaurantViewModel(RestaurantService restaurantService)
    {
        RestaurantService = restaurantService;
    }
    
    [RelayCommand]
    private async void AddNewRestaurant()
    {
        RestaurantService.AddNewRestaurant(NewRestaurant);
        await Shell.Current.GoToAsync("..", true);
    }
}