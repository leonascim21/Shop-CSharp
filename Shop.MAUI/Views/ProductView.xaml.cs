using Shop.MAUI.ViewModels;

namespace Shop.MAUI.Views;

[QueryProperty(nameof(ProductId), "productId")]
public partial class ProductView : ContentPage
{
    public ProductView()
    {
        InitializeComponent();
        BindingContext = new ProductViewModel();
    }

    public int ProductId
    {
        get
        {
            return (BindingContext as ProductViewModel)?.ProductId ?? 0;
        }
        set
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.ProductId = value;
            viewModel.FindProduct();
            BindingContext = viewModel;
        }
    }

    private void GoToInventoryPage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    public void SaveProduct(object sender, EventArgs e)
    {
        var product = BindingContext as ProductViewModel;
        if (product != null)
        {
            product.Save();
            Shell.Current.GoToAsync("//InventoryPage");
        }
    }
}