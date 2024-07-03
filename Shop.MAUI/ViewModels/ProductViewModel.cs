using Shop.Library.Services;
using Shop_CSharp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shop.MAUI.ViewModels
{
    class ProductViewModel : INotifyPropertyChanged
    {
        public Product? Model { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel()
        {
            Model = new Product();
        }

        public ProductViewModel(Product? p)
        {
            Model = p ?? new Product();
        }

        public void FindProduct()
        {
            Model = InventoryServiceProxy.Current.Products
                .FirstOrDefault(p => p.Id == ProductId) ?? new Product();
        }

        public void Save()
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
            NotifyPropertyChanged(nameof(MarkdownAsString));
        }

        public string PriceAsString
        {
            get
            {
                if (Model?.Id != 0)
                {
                    return Model?.Price.ToString() ?? "0";
                }
                else
                    { return string.Empty; }
            }
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
            get
            {
                if (Model?.Id != 0)
                {
                    return Model?.Quantity.ToString() ?? "0";
                }
                else
                { return string.Empty; }
            }
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
                    Model.Quantity = 0;
                }
                NotifyPropertyChanged(nameof(Model.Quantity));
            }
        }
        public List<string> MarkdownOptions
        {
            get
            {
                return new List<string>
                {
                    "0%", "5%", "10%", "15%", "20%", "25%", "30%", "35%", "40%", "45%", "50%",
                        "55%", "60%", "65%", "70%", "75%", "80%", "85%", "90%", "95%", "100%"
                };
            }
        }
        public string MarkdownAsString
        {
            get
            {
                if (Model?.Id != 0)
                {
                    return $"{(Model?.Markdown)*100}%" ?? "0%";
                }
                else
                { return string.Empty; }
            }
            set
            {
                if (Model == null)
                {
                    return;
                }
                string? noPercent = value?.Replace("%", "");
                if (double.TryParse(noPercent, out var markdown))
                {
                    Model.Markdown = markdown / 100;
                }
                else
                {
                    Model.Markdown = 0;
                }
                NotifyPropertyChanged(nameof(Model.Markdown));
            }
        }
        public string MarkdownDisplay
        {
            get
            {
                if (Model != null)
                    return $"Markdown: {Math.Round(Model.Markdown * 100, 0)}%";

                return string.Empty;
            }
        }
        public string QuantityDisplay
        {
            get
            {
                return $"Quantity: {Model?.Quantity}";
            }
        }
        public string BogoDisplay
        {
            get
            {
                return $"Buy 1 Get 1: {Model?.Bogo}";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
