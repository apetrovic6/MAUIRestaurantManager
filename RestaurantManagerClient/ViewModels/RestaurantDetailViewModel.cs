using CommunityToolkit.Mvvm.ComponentModel;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

[QueryProperty(nameof(RestaurantId), "resId")]
public partial class RestaurantDetailViewModel : ObservableObject
{
    private RestaurantService RestaurantService { get; set; }

    public RestaurantDetailViewModel(RestaurantService restaurantService)
    {
        RestaurantService = restaurantService;
    }

    public int RestaurantId
    {
        get => _restaurantId;
        set
        {
            if (value == _restaurantId) return;
            _restaurantId = value;
            OnPropertyChanged();
            GetRestaurant();
        }
    }

    [ObservableProperty] private Restaurant _fetchedRestaurant;
    private int _restaurantId;
    
    private void GetRestaurant()
    {
        FetchedRestaurant = RestaurantService.GetRestaurantById(RestaurantId);
    }
}