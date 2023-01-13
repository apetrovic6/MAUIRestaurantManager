using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop.MenuPages;

public partial class MenuPageDesktop : ContentPage
{
    public MenuPageDesktop(MenuPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = (MenuPageViewModel)BindingContext;
        vm.GetMenus();
    }
}