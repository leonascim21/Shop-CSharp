using Shop.MAUI.ViewModels;
using Shop_CSharp.Models;

namespace Shop.MAUI.Views;

public partial class ShoppingCartView : ContentPage
{
	public ShoppingCartView()
	{
        InitializeComponent();
		BindingContext = new ShoppingCartViewModel();
	}
    private void GoToShopPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ShopPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ShoppingCartViewModel)?.Refresh();
    }

    private void RemoveFromCart(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        ShoppingCartViewModel? product = button?.CommandParameter as ShoppingCartViewModel;


        if (product != null)
        {
            (BindingContext as ShoppingCartViewModel)?.RemoveFromCart(product);
        }
        (BindingContext as ShoppingCartViewModel)?.Refresh();
    }

    private void CheckoutCart(object sender, EventArgs e)
    {
        (BindingContext as ShoppingCartViewModel).Checkout();
        (BindingContext as ShoppingCartViewModel)?.Refresh();
    }
}