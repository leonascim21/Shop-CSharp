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
    class ShopViewModel : INotifyPropertyChanged
    {
        public List<ProductViewModel> Products
        {
            get
            {
                return InventoryServiceProxy.Current.Products.Where(p => p.Quantity > 0)
                    .Select(p => new ProductViewModel(p)).ToList()
                    ?? new List<ProductViewModel>();
            }
        }

        public List<ShoppingCartViewModel> ShoppingCartList
        {
            get
            {
                return ShoppingCartServiceProxy.Current.CartList.Where(c => c != null)
                    .Select(c => new ShoppingCartViewModel(c)).ToList()
                    ?? new List<ShoppingCartViewModel>();
            }
        }

        private ShoppingCartViewModel? selectedCart;
        public ShoppingCartViewModel SelectedCart
        {
            get => selectedCart ?? new ShoppingCartViewModel();
            set
            {
                selectedCart = value;
                CartId = selectedCart?.Cart?.Id ?? 0;
                NotifyPropertyChanged();
            }
        }

        int CartId { get; set; }

        public void AddToCart(Product product)
        {
            ShoppingCartServiceProxy.Current.AddOrUpdateCart(product, CartId);
            Refresh();
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Products));
            NotifyPropertyChanged(nameof(ShoppingCartList));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
