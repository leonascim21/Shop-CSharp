using Shop.MAUI.ViewModels;
using Shop_CSharp.Models;

namespace Shop.MAUI.Views;

[QueryProperty(nameof(ProductId), "productId")]
public partial class ProductView : ContentPage
{
    public int ProductId { get; set; } 
    public ProductView()
    {
        InitializeComponent();
        this.NavigatedTo += ContentPage_NavigatedTo;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProductViewModel(ProductId);
    }

    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    public void SaveProduct(object sender, EventArgs e)
    {
        (BindingContext as ProductViewModel)?.Save();
        Shell.Current.GoToAsync("//InventoryPage");
    }
}