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
        public ShoppingCartViewModel(int cartId = 1)
        {

            Cart = ShoppingCartServiceProxy.Current.CartList.First(c => c.Id == cartId);
            Refresh();
        }
        public ShoppingCartViewModel(ShoppingCart c)
        {
            Cart = c;
        }

        public ShoppingCart Cart { get; set; }


        public List<ProductViewModel> Products
        {
            get
            {
                ShoppingCart? cart = ShoppingCartServiceProxy.Current.CartList.FirstOrDefault(c => c.Id == Cart.Id);

                return cart?.Contents?
                    .Where(p => p != null)
                    .Select(p => new ProductViewModel(p))
                    .ToList() ?? new List<ProductViewModel>();
            }
        }

        public ProductViewModel? ProductToRemove { get; set; }
        public void RemoveFromCart()
        {
            if (ProductToRemove != null && ProductToRemove.Model != null)
            {
                ShoppingCartServiceProxy.Current.RemoveFromCart(ProductToRemove.Model, Cart.Id);
                Refresh();
            }
        }

        public void Checkout()
        {
            ShoppingCartServiceProxy.Current.Checkout(Cart.Id);
            Refresh();
        }

        public decimal CartSubtotal { 
            get
            {
                decimal Subtotal = Products.Where(p => p != null)
                    .Aggregate(0m, (accumulator, product) => 
                    accumulator + toDecimal(product.DisplayTotalItemPrice));

                return Subtotal;
            } 
        }

        public decimal CartTax
        {
            get
            {
                return CartSubtotal * InventoryServiceProxy.Current.TaxRate;
            }
        }

        public string DisplaySubtotal
        {
            get
            {
                return $"Subtotal: {CartSubtotal:C}";
            }
        }

        public string DisplayTax
        {
            get
            {
                decimal taxRate = InventoryServiceProxy.Current.TaxRate * 100;
                return $"Tax ({Math.Round(taxRate, 2)}%): {CartTax:C}";
            }
        }

        public string DisplayTotal
        {
            get
            {
                return $"Total: {CartTax + CartSubtotal:C}";
            }
        }

        private decimal toDecimal(string s)
        {
            string noDollarSign = s.Replace("$", "");
            decimal.TryParse(noDollarSign, out var result);
            return result;
        }
        
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Products));
            NotifyPropertyChanged(nameof(Cart));
            NotifyPropertyChanged(nameof(DisplaySubtotal));
            NotifyPropertyChanged(nameof(DisplayTax));
            NotifyPropertyChanged(nameof(DisplayTotal));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
