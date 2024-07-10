using Shop.MAUI.ViewModels;
using Shop_CSharp.Models;

namespace Shop.MAUI.Views;

[QueryProperty(nameof(CartId), "CartId")]
public partial class ShoppingCartView : ContentPage
{
    public int CartId { get; set; }
    public ShoppingCartView()
	{
        InitializeComponent();

	}

    private void GoToShopPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ShopPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
            BindingContext = new ShoppingCartViewModel(CartId);
    }

    private void RemoveFromCart(object sender, EventArgs e)
    {
        (BindingContext as ShoppingCartViewModel).ProductToRemove = (sender as ImageButton).CommandParameter as ProductViewModel;
        (BindingContext as ShoppingCartViewModel)?.RemoveFromCart();
        (BindingContext as ShoppingCartViewModel)?.Refresh();
    }

    private void CheckoutCart(object sender, EventArgs e)
    {
            (BindingContext as ShoppingCartViewModel)?.Checkout();
            (BindingContext as ShoppingCartViewModel)?.Refresh();
    }
}