using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class MenuPageViewModel : ObservableObject
{
    private MenuService MenuService { get; set; }
    private RestaurantService RestaurantService { get; set; }

    [ObservableProperty] 
    private List<Menu> _menus;

    [ObservableProperty] 
    private List<Restaurant> _restaurants;

    [ObservableProperty] private Menu _selectedMenu = new();
    public MenuPageViewModel(MenuService menuService, RestaurantService restaurantService)
    {
        MenuService = menuService;
        RestaurantService = restaurantService;
    }

    public void GetMenus()
    {
        Menus = MenuService.GetAll();
        Restaurants = RestaurantService.GetAllRestaurants();
    }

    
    [RelayCommand]
    private void UpdateMenu(Menu menu)
    {
        MenuService.UpdateMenu(menu);
        GetMenus();
    }

    [RelayCommand]
    private void DeleteMenu(int id)
    {
        MenuService.RemoveMenu(id);
        GetMenus();
    }
    
    [RelayCommand]
    private async void GoToAddMenuPage()
    {
        await Shell.Current.GoToAsync("AddMenuPage", false);
    }

    [RelayCommand]
    public async void GoToMenuDetails()
    {
        await Shell.Current.GoToAsync($"MenuDetailPage?menuId={SelectedMenu.Oid}");
    }
}