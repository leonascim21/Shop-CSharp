using Shop.Library.Services;
using Shop_CSharp.Models;

namespace Shop.MAUI.ViewModels
{
    class AddProductViewModel
    {
        public Product? Model { get; set; }

        public string PriceAsString
        {
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (decimal.TryParse(value, out var price))
                {
                    Model.Price = price;
                }
                else
                {

                }
            }
        }

        public string QuantityAsString
        {
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (int.TryParse(value, out var quantity))
                {
                    Model.Quantity = quantity;
                }
                else
                {

                }
            }
        }


        public AddProductViewModel() 
        {
            Model = new Product();
        }

        public AddProductViewModel(Product? p)
        {
            if (p != null)
                Model = p;
            else 
                Model = new Product();
        }

        public void Add()
        {
            if (Model != null)
            {
                InventoryServiceProxy.Current.AddOrUpdate(Model);
                ResetFields();
            }
        }

        public void ResetFields()
        {
            Model = new Product();
        }
    }
}
