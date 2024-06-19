using Shop.MAUI.ViewModels;

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
}