using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop.MenuPages;

public partial class AddMenuPageDesktop : ContentPage
{
    public AddMenuPageDesktop(AddMenuPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}