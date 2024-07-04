﻿using Shop.Library.Models;
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
        public ShoppingCartViewModel()
        {
        }
        public ShoppingCartViewModel(ShoppingCart c)
        {
            Cart = c;
        }

        public void LoadCart(int cartId)
        {
            CartId = cartId;
            Cart = ShoppingCartServiceProxy.Current.CartList.FirstOrDefault(c => c.Id == cartId);
            Refresh();
        }

        public ShoppingCart? Cart { get; set; }

        public int CartId { get; set; }

        public List<ProductViewModel> Products
        {
            get
            {
                ShoppingCart? Cart = ShoppingCartServiceProxy.Current.CartList.FirstOrDefault(c => c.Id == CartId);

                return Cart?.Contents?
                    .Where(p => p != null)
                    .Select(p => new ProductViewModel(p))
                    .ToList() ?? new List<ProductViewModel>();
            }
        }
        public void RemoveFromCart(ProductViewModel product)
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

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Products));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
