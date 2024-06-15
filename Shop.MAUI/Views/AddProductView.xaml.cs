using Shop.MAUI.ViewModels;

namespace Shop.MAUI.Views;

public partial class AddProductView : ContentPage
{
	public AddProductView()
	{
		InitializeComponent();
        BindingContext = new AddProductViewModel();
	}

    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    private void AddProduct(object sender, EventArgs e)
    {
        AddProductViewModel? product = BindingContext as AddProductViewModel;
        if (product != null)
        {
            product.Add();
            Shell.Current.GoToAsync("//InventoryPage");
        }
    }
}