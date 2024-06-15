using Shop.Library.Services;
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
