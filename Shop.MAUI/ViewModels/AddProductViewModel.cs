using Shop.Library.Services;
using Shop_CSharp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shop.MAUI.ViewModels
{
    class AddProductViewModel : INotifyPropertyChanged
    {
        public Product? Model { get; set; }

        public string PriceAsString
        {
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (decimal.TryParse(value, out var price))
                {
                    Model.Price = price;
                }
                else
                {
                    Model.Price = 0;
                }
                NotifyPropertyChanged(nameof(Model.Price));
            }
        }

        public string QuantityAsString
        {
            set
            {
                if (Model == null)
                {
                    return;
                }
                if (int.TryParse(value, out var quantity))
                {
                    Model.Quantity = quantity;
                }
                else
                {
                    Model.Price = 0;
                }
                NotifyPropertyChanged(nameof(Model.Quantity));
            }
        }


        public AddProductViewModel() 
        {
            Model = new Product();
        }

        public AddProductViewModel(Product? p)
        {
            Model = p ?? new Product();
        }

        public void Add()
        {
            if (Model != null)
            {
                InventoryServiceProxy.Current.AddOrUpdate(Model);
                ResetFields();
            }
        }

        public void ResetFields()
        {
            Model = new Product();
            NotifyPropertyChanged(nameof(Model));
            NotifyPropertyChanged(nameof(PriceAsString));
            NotifyPropertyChanged(nameof(QuantityAsString));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
