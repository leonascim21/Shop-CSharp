using Shop.Library.Services;
using Shop.MAUI.ViewModels;
using Shop_CSharp.Models;

namespace Shop.MAUI.Views;

public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
		BindingContext = new ShopViewModel();
	}

    private void GoToHomePage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void GoToShoppingCartPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ShoppingCartPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ShopViewModel)?.Refresh();
    }

    private void AddToCart(object sender, EventArgs e)
    {
        var button = sender as Button;
        ShopViewModel? product = button?.CommandParameter as ShopViewModel;

        if(product == null || product.Model == null) { return; }


        Product productToAdd = new Product
        {
            Id = product.Model.Id,
            Name = product.Model.Name ?? string.Empty,
            Description = product.Model.Description ?? string.Empty,
            Price = product.Model.Price,
            Quantity = product.SelectedQuantity
        };

        if (productToAdd != null)
        {
            (BindingContext as ShopViewModel)?.AddToCart(productToAdd);
        }
        (BindingContext as ShopViewModel)?.Refresh();
    }

}