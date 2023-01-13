using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop.MenuPages;

public partial class MenuDetailPageDesktop : ContentPage
{
    public MenuDetailPageDesktop(MenuDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}