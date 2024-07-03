using Shop.MAUI.ViewModels;

namespace Shop.MAUI.Views;

public partial class AddProductView : ContentPage
{
	public AddProductView()
	{
		InitializeComponent();
        BindingContext = new ProductViewModel();
	}

    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    private void AddProduct(object sender, EventArgs e)
    {
        ProductViewModel? product = BindingContext as ProductViewModel;
        if (product != null)
        {
            product.Add();
            Shell.Current.GoToAsync("//InventoryPage");
        }
    }
}