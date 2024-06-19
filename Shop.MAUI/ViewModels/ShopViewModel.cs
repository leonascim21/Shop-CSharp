﻿using Shop.Library.Services;
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

        
        public void AddToCart(ShopViewModel product)
        {
            ShoppingCartServiceProxy.Current.AddToCart(product.Model ?? new Product());
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
