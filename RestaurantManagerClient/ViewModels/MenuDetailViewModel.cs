using CommunityToolkit.Mvvm.ComponentModel;
using RestaurantManagerClient.Models;
using RestaurantManagerClient.Services;

namespace RestaurantManagerClient.ViewModels;

[QueryProperty(nameof(MenuId), "menuId")]
public partial class MenuDetailViewModel : ObservableObject
{
    private int _menuId;
    private MenuService MenuService {get; set; }

    [ObservableProperty] 
    private Menu _fetchedMenu;
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

    public MenuDetailViewModel(MenuService menuService)
    {
        MenuService = menuService;
    }

    private void GetMenu()
    {
        FetchedMenu = MenuService.GetMenuById(MenuId);
    }
}