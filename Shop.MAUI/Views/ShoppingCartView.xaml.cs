using Shop.MAUI.ViewModels;
using Shop_CSharp.Models;

namespace Shop.MAUI.Views;

[QueryProperty(nameof(CartId), "CartId")]
public partial class ShoppingCartView : ContentPage
{
	public ShoppingCartView()
	{
        InitializeComponent();
		BindingContext = new ShoppingCartViewModel();
	}

    private int cartId;
    public int CartId
    {
        get
        {
          return cartId;
        }
        set
        {
            cartId = value;
            LoadCart(cartId);
        }
    }

    private void LoadCart(int cartId)
    {
        var viewModel = BindingContext as ShoppingCartViewModel;
        if (viewModel != null)
        {
            viewModel.LoadCart(cartId);
            viewModel.Refresh();
        }
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
        ProductViewModel? product = button?.CommandParameter as ProductViewModel;


        if (product != null)
        {
                (BindingContext as ShoppingCartViewModel)?.RemoveFromCart(product);
        }
        (BindingContext as ShoppingCartViewModel)?.Refresh();
    }

    private void CheckoutCart(object sender, EventArgs e)
    {
            (BindingContext as ShoppingCartViewModel)?.Checkout();
            (BindingContext as ShoppingCartViewModel)?.Refresh();
    }
}