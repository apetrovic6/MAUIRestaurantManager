﻿namespace RestaurantManagerClient;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        #if ANDROID || IOS
            MainPage = new AppShellMobile();
        #else
            MainPage = new AppShellDesktop();
        #endif
    }
}