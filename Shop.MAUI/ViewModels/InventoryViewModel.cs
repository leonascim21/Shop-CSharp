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
        public List<AddProductViewModel> Products
        {
            get
            {
                return InventoryServiceProxy.Current.Products.Where(p => p != null)
                    .Select(p => new AddProductViewModel(p)).ToList()
                    ?? new List<AddProductViewModel>();
            }
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
