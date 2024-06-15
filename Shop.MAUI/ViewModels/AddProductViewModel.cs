using Shop.Library.Services;
using Shop_CSharp.Models;

namespace Shop.MAUI.ViewModels
{
    class AddProductViewModel
    {
        public Product? Model { get; set; }

        public override string ToString()
        {
            if (Model == null)
            {
                return string.Empty;
            }
            return $"[{Model.Id}]  Name:{Model.Name}  Price:{Model.Price:C}";
        }

        public string DisplayPrice
        {
            get
            {
                if (Model == null) { return string.Empty; }
                return $"{Model.Price:C}";
            }
        }

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
            InventoryServiceProxy.Current.AddOrUpdate(Model);
        }
    }
}
