using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shop.MAUI.Views;
using Shop_CSharp.Models;
using Shop.Library.Services;

namespace Shop.MAUI.ViewModels
{
    internal class InventoryViewModel : INotifyPropertyChanged
    {
        public List<ProductViewModel> Products
        {
            get
            {
                return InventoryServiceProxy.Current.Products.Where(p => p != null)
                    .Select(p => new ProductViewModel(p)).ToList()
                    ?? new List<ProductViewModel>();
            }
        }

        public void Refresh()
        {
            InventoryServiceProxy.Current.GetProducts();
            NotifyPropertyChanged(nameof(Products));
        }

        public ProductViewModel? ProductToRemove { get; set; }
        public void Remove()
        {
            if (ProductToRemove != null)
            {
                InventoryServiceProxy.Current.Remove(ProductToRemove.Model ?? new Product());
                Refresh();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
