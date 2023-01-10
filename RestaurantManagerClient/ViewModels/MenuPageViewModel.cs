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
        
        GetMenus();
    }

    private void GetMenus()
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
    private void DeleteMenu(string id)
    {
        MenuService.RemoveMenu(id);
        GetMenus();
    }
    
    [RelayCommand]
    private async void GoToAddMenuPage()
    {
        // Get current page
        var page = Shell.Current.Navigation.NavigationStack.LastOrDefault();
        
        // Load new page
        await Shell.Current.GoToAsync("AddMenuPage", false);


    }
}