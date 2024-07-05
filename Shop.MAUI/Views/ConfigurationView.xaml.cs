using Shop.MAUI.ViewModels;

namespace Shop.MAUI.Views;

public partial class ConfigurationView : ContentPage
{
	public ConfigurationView()
	{
		InitializeComponent();
		BindingContext = new ConfigurationViewModel();
	}

    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    private void SaveChanges(object sender, EventArgs e)
    {
        (BindingContext as ConfigurationViewModel).SaveChanges();
        Shell.Current.GoToAsync("//InventoryPage");
    }

}