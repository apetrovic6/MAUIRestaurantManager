﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagerClient.ViewModels;

namespace RestaurantManagerClient.Views.Desktop;

public partial class MainPageDesktop : ContentPage
{
    public MainPageDesktop(MainPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}