namespace Shop.MAUI.Views;

public partial class AddProductView : ContentPage
{
	public AddProductView()
	{
		InitializeComponent();
	}

    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    private void AddProduct(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }
}