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
        if ((BindingContext as ShopViewModel)?.SelectedCart.Cart != null)
        {
            int cartId = (BindingContext as ShopViewModel).SelectedCart.Cart.Id;
            Shell.Current.GoToAsync($"//ShoppingCartPage?CartId={cartId}");
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ShopViewModel)?.Refresh();
    }

    private void AddToCart(object sender, EventArgs e)
    {
        var button = sender as Button;
        ProductViewModel? product = button?.CommandParameter as ProductViewModel;

        if(product == null || product.Model == null) { return; }


        Product productToAdd = new Product
        {
            Id = product.Model.Id,
            Name = product.Model.Name ?? string.Empty,
            Description = product.Model.Description ?? string.Empty,
            Price = product.Model.Price,
            Quantity = product.SelectedQuantity,
            Bogo = product.Model.Bogo,
            Markdown = product.Model.Markdown
        };

        if (productToAdd != null)
        {
            (BindingContext as ShopViewModel)?.AddToCart(productToAdd);
        }
        (BindingContext as ShopViewModel)?.Refresh();
    }

    private void GoToAddShoppingCartPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddShoppingCartPage");
        (BindingContext as ShopViewModel)?.Refresh();
    }

}