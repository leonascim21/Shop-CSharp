namespace Shop.MAUI.Views;
using Shop.MAUI.ViewModels;
public partial class AddShoppingCartView : ContentPage
{
	public AddShoppingCartView()
	{
		InitializeComponent();
		BindingContext = new AddShoppingCartViewModel();
	}

    private void GoToShopPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ShopPage");
    }

    public void CreateCart(object sender, EventArgs e)
    {
        (BindingContext as AddShoppingCartViewModel).CreateCart();
        Shell.Current.GoToAsync("//ShopPage");
    }

}