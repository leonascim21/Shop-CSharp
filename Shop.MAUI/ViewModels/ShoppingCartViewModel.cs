using Shop.Library.Models;
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
    internal class ShoppingCartViewModel : INotifyPropertyChanged
    {


        public ShoppingCartViewModel(ShoppingCart c)
        {
            Cart = c;
        }

        public ShoppingCart? Cart { get; set; }

        public List<ShoppingCartViewModel> Products
        {
            get
            {
                ShoppingCart? Cart = ShoppingCartServiceProxy.Current.CartList.FirstOrDefault(c => c.Id == CartId);

                return Cart?.Contents?
                    .Where(p => p != null)
                    .Select(p => new ShoppingCartViewModel(p))
                    .ToList() ?? new List<ShoppingCartViewModel>();
            }
        }
        public Product? Model { get; set; }

        public ShoppingCartViewModel()
        {
            Model = new Product();
            Cart = new ShoppingCart();
        }

        public ShoppingCartViewModel(Product? p)
        {
            if (p != null)
                Model = p;
            else
                Model = new Product();
        }

        public void RemoveFromCart(ShoppingCartViewModel product)
        {
            Product ProductToRemove = product?.Model ?? new Product();
            ShoppingCartServiceProxy.Current.RemoveFromCart(ProductToRemove, Cart.Id);
            Refresh();
        }

        public void Checkout()
        {
            ShoppingCartServiceProxy.Current.Checkout(Cart.Id);
            Refresh();
        }

        public string DisplayPriceQuantity
        {
            get
            {
                return $"{Model?.Price:C}  ({Model?.Quantity} units)";
            }
        }

        public string DisplayTotalItemPrice
        {
            get
            {
                return $"{Model?.Price * Model?.Quantity:C}";
            }
        }

        public string DisplayCartPrice
        {
            get
            {
                decimal TotalPrice = Products
                    .Where(p => p != null)
                    .Aggregate(0m, (accumulator, product) => accumulator + (product.Model.Price * product.Model.Quantity));

                return $"Total Price: {TotalPrice:C}";
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Products));
            NotifyPropertyChanged(nameof(DisplayCartPrice));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
