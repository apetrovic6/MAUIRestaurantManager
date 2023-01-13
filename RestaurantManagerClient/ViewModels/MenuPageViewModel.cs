using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

public partial class MenuPageViewModel : ObservableObject
{
    private MenuService MenuService { get; set; }

    [ObservableProperty] 
    private List<Menu> _menus;

    public MenuPageViewModel(MenuService menuService)
    {
        MenuService = menuService;
        RestaurantService = restaurantService;
    }

    public void GetMenus()
    {
        Menus = MenuService.GetAll();
    }

    [RelayCommand]
    private void Refresh()
    {
        Menus = MenuService.GetAll();
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
}