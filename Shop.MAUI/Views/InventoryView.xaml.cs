using Shop.MAUI.ViewModels;
using Shop_CSharp.Models;

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

    private void GoToEditProductPage(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        AddProductViewModel? product = button?.CommandParameter as AddProductViewModel;
        if (product?.Model != null)
        {
            Shell.Current.GoToAsync($"//EditProductPage?productId={product.Model.Id}");
        }
    }


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryViewModel)?.Refresh();
    }

    private void DeleteProduct(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        AddProductViewModel? product = button?.CommandParameter as AddProductViewModel;
        if (product != null)
        {
            (BindingContext as InventoryViewModel)?.Remove(product);
        }
        (BindingContext as InventoryViewModel)?.Refresh();
    }

}