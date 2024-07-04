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
    internal class AddShoppingCartViewModel : INotifyPropertyChanged
    {
        private string? name;
        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void CreateCart()
        {
            ShoppingCartServiceProxy.Current.AddCart(Name ?? string.Empty);
            Name = string.Empty;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
