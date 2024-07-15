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

        public string CartPrice
        {
            get
            {
                if (selectedCart == null) return "$0.00";

                return $"{selectedCart.CartSubtotal:C}";
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
                RefreshCartPrice();
            }
        }

        int CartId { get; set; }

        public ProductViewModel? ProductToAdd { get; set; }

        public async void AddToCart()
        {
            if (ProductToAdd!= null && ProductToAdd.Model != null && CartId != 0)
            {   
                int quantityToAdd = ProductToAdd.SelectedQuantity;
                Product product = new Product(ProductToAdd.Model);
                product.Quantity = quantityToAdd;

                await ShoppingCartServiceProxy.Current.AddOrUpdateCart(product, CartId);
                RefreshCartPrice();
                RefreshProducts();
            }
        }

        public void RefreshProducts()
        {
            InventoryServiceProxy.Current.Get();
            NotifyPropertyChanged(nameof(Products));
        }

        private int CartCount { get; set; }
        public void RefreshCarts()
        {
            ShoppingCartServiceProxy.Current.Get();
            if (CartCount < ShoppingCartList.Count)
            {
                NotifyPropertyChanged(nameof(ShoppingCartList));
                CartCount = ShoppingCartList.Count;
            }   
        }
        public void RefreshCartPrice()
        {
            ShoppingCartServiceProxy.Current.Get();
            NotifyPropertyChanged(nameof(CartPrice));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
