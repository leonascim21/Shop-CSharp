using Shop.MAUI.ViewModels;

namespace Shop.MAUI.Views;

public partial class InventoryView : ContentPage
{
	public InventoryView()
	{
        InitializeComponent();
        BindingContext = new InventoryViewModel();
	}
    private void GoToHomePage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void GoToAddProductPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddProductPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryViewModel)?.Refresh();
    }
}