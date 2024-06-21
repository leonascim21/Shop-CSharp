using Shop.Library.Services;
using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.MAUI.ViewModels
{
    class ShopViewModel : INotifyPropertyChanged
    {
        public List<ShopViewModel> Products
        {
            get
            {
                return InventoryServiceProxy.Current.Products.Where(p => p.Quantity > 0)
                    .Select(p => new ShopViewModel(p)).ToList()
                    ?? new List<ShopViewModel>();
            }
        }

        public Product? Model { get; set; }

        public ShopViewModel()
        {
            Model = new Product();
        }

        public ShopViewModel(Product? p)
        {
            if (p != null)
                Model = p;
            else
                Model = new Product();
        }

        public List<int> QuantityOptions
        {
            get
            {
                if (Model?.Quantity < 50)
                    return Enumerable.Range(1, Model.Quantity).ToList();
                else
                    return Enumerable.Range(1, 50).ToList();
            }
        }

        private int selectedQuantity;
        public int SelectedQuantity
        {
            get { return selectedQuantity; }
            set
            {
                if (selectedQuantity != value)
                {
                    selectedQuantity = value;
                    NotifyPropertyChanged(nameof(SelectedQuantity));
                }
            }
        }

        public void AddToCart(Product product)
        {
            ShoppingCartServiceProxy.Current.AddOrUpdateCart(product);
            Refresh();
        }

        public string TotalCartPrice
        {
            get
            {
                if(ShoppingCartServiceProxy.Current.Cart.Contents == null) { return string.Empty; }

                decimal TotalPrice = ShoppingCartServiceProxy.Current.Cart.Contents
                    .Where(p => p != null)
                    .Aggregate(0m, (accumulator, product) => accumulator + (product.Price * product.Quantity));

                return $"  {TotalPrice:C}";
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Products));
            NotifyPropertyChanged(nameof(TotalCartPrice));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
