﻿namespace Shop.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void GoToInventoryPage(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InventoryPage");
        }
    }

}
