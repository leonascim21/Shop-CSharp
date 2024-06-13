namespace Shop.MAUI.Views;

public partial class InventoryView : ContentPage
{
	public InventoryView()
	{
        InitializeComponent();
	}
    private void GoToHomePage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void GoToAddProductPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddProductPage");
    }

}