using Shop.MAUI.ViewModels;
using Shop_CSharp.Models;

namespace Shop.MAUI.Views;

[QueryProperty(nameof(ProductId), "productId")]
public partial class EditProductView : ContentPage
{

    public EditProductView()
    {
        InitializeComponent();
    }

    public int ProductId
    {
        get
        {
            return (BindingContext as EditProductViewModel)?.ProductId ?? 0;
        }
       set
        {
                EditProductViewModel viewModel = new EditProductViewModel();
                viewModel.ProductId = value;
                viewModel.FindProduct();
                BindingContext = viewModel;
        }
    }

    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    public void SaveProduct(object sender , EventArgs e)
    {
        EditProductViewModel? product = BindingContext as EditProductViewModel;
        if (product != null)
        {
            product.Save();
            Shell.Current.GoToAsync("//InventoryPage");
        }
    }
}