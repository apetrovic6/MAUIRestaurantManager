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

    [ObservableProperty] private string _newName;

    [ObservableProperty] private string _resId;
    
    public MenuPageViewModel(MenuService menuService)
    {
        MenuService = menuService;
        
        GetMenus();
    }

    private void GetMenus()
    {
        Menus = MenuService.GetAll();
    }

    [RelayCommand]
    private void AddMenu()
    {
        var a = new Menu()
        {
            Name = NewName,
            Restaurant = new() { Id = ResId }
        };
        MenuService.AddNewMenu(NewName, ResId);
        
        GetMenus();
    }
}