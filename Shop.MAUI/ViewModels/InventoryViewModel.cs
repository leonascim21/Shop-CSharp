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
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

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
            InventoryServiceProxy.Current.Get();
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

        public async Task<List<Product>> ImportProducts()
        {
            var fileResult = await FilePicker.Default.PickAsync();
            if (fileResult == null || !fileResult.FileName.EndsWith(".csv")) return new List<Product>();

            using (var reader = new StreamReader(fileResult.FullPath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
            }))
            {

                var products = new List<Product>();
                try
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var product = new Product
                        {
                            Id = csv.GetField<int>("Id"),
                            Name = csv.GetField("Name") ?? string.Empty,
                            Description = csv.GetField("Description") ?? string.Empty,
                            Price = csv.GetField<decimal?>("Price") ?? 0m,
                            Quantity = csv.GetField<int?>("Quantity") ?? 0,
                            Markdown = csv.GetField<double?>("Markdown") ?? 0,
                            Bogo = csv.GetField<bool?>("Bogo") ?? false
                        };
                        products.Add(product);
                    }
                }
                catch (Exception e) 
                {
                    foreach (Product p in products)
                    {
                        await InventoryServiceProxy.Current.AddOrUpdate(p);
                    }
                    return products; 
                }
                
                foreach (Product p in products)
                {
                    await InventoryServiceProxy.Current.AddOrUpdate(p);
                }

                return products;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
