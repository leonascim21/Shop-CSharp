using Shop.Library.Services;
using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.MAUI.ViewModels
{
    class EditProductViewModel
    {
        public void FindProduct()
        {
            Model = InventoryServiceProxy.Current.Products
                .FirstOrDefault(p => p.Id == ProductId) ?? new Product();
        }

        public int ProductId { get; set; }

        public Product? Model { get; set; }
        public string PriceAsString
        {
            get
            {
                return Model?.Price.ToString() ?? "0";
            }

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
                    Model.Price = 0;
                }
            }
        }

        public string QuantityAsString
        {
            get
            {
                return Model?.Quantity.ToString() ?? "0";
            }

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
                    Model.Price = 0;
                }
            }
        }

        public EditProductViewModel()
        {
            Model = new Product();
        }

        public EditProductViewModel(Product? p)
        {
            Model = p ?? new Product();
        }

        public void Save()
        {
            if (Model != null)
            {
                InventoryServiceProxy.Current.AddOrUpdate(Model);
            }
        }
    }
}
