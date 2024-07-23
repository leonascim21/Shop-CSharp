namespace Shop.MAUI.Views;

public partial class ImportView : ContentPage
{
	public ImportView()
	{
		InitializeComponent();
	}
    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }
}