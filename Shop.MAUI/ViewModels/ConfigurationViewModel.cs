using Shop.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.MAUI.ViewModels
{
    internal class ConfigurationViewModel
    {
        public decimal? TaxRate { get; set; }
        public string? TaxRateAsString {
            set
            {
                if (value != null)
                {
                    string noPercent = value.Replace("%", "");
                    if (double.TryParse(noPercent, out var taxRate))
                    {
                        TaxRate = (decimal)(taxRate / 100);
                    }
                }
            }
        }

        public void SaveChanges()
        {
            if (TaxRate != null)
            {
                InventoryServiceProxy.Current.TaxRate = (decimal)TaxRate;
            }
        }
    }
}
