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
        (BindingContext as ShopViewModel)?.RefreshProducts();
        (BindingContext as ShopViewModel)?.RefreshCarts();
        (BindingContext as ShopViewModel)?.RefreshCartPrice();
    }

    private void AddToCart(object sender, EventArgs e)
    {
        (BindingContext as ShopViewModel).ProductToAdd =  (sender as Button)?.CommandParameter as ProductViewModel;
        (BindingContext as ShopViewModel)?.AddToCart();
    }

    private void GoToAddShoppingCartPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddShoppingCartPage");
    }

}