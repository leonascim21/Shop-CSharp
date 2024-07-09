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
    private void GoToConfigurationPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ConfigurationPage");
    }

    private void GoToAddProductPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProductPage");
    }

    private void GoToEditProductPage(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        ProductViewModel? product = button?.CommandParameter as ProductViewModel;
        if (product?.Model != null)
        {
            Shell.Current.GoToAsync($"//ProductPage?productId={product.Model.Id}");
        }
    }


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryViewModel)?.Refresh();
    }

    private void DeleteProduct(object sender, EventArgs e)
    {
        (BindingContext as InventoryViewModel).ProductToRemove = (sender as ImageButton).CommandParameter as ProductViewModel;
        (BindingContext as InventoryViewModel)?.Remove();
        (BindingContext as InventoryViewModel)?.Refresh();
    }
}