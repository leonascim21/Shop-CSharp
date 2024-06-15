using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Library.Services
{
    public class InventoryServiceProxy
    {
        private static InventoryServiceProxy? instance;
        private static object instanceLock = new object();

        private List<Product> products;

        public ReadOnlyCollection<Product> Products
        {
            get
            {
                return products.AsReadOnly();
            }
        }

        private int NextId
        {
            get
            {
                if (!products.Any())
                {
                    return 1;
                }

                return products.Select(p => p.Id).Max() + 1;
            }
        }

        public Product AddOrUpdate(Product p)
        {
            bool isAdd = false;
            if (p.Id == 0)
            {
                isAdd = true;
                p.Id = NextId;
            }

            if (isAdd)
            {
                products.Add(p);
            }

            return p;
        }

        public void Remove(Product p)
        {
            products.Remove(p);
        }

        private InventoryServiceProxy()
        {
            products = new List<Product>{
                new Product{Id = 1, Name = "Apples", Price=1.75M, Quantity=50, Description="Fresh red apples"},
                new Product{Id = 2, Name = "Bananas", Price=0.99M, Quantity=100, Description="Ripe yellow bananas"},
                new Product{Id = 3, Name = "Oranges", Price=1.50M, Quantity=75, Description="Juicy oranges"},
                new Product{Id = 4, Name = "Milk", Price=2.99M, Quantity=200, Description="1 gallon of whole milk"},
                new Product{Id = 5, Name = "Bread", Price=2.50M, Quantity=150, Description="Whole wheat bread loaf"},
                new Product{Id = 6, Name = "Eggs", Price=3.99M, Quantity=180, Description="One dozen large eggs"},
                new Product{Id = 7, Name = "Cheese", Price=5.00M, Quantity=80, Description="Cheddar cheese block"},
                new Product{Id = 8, Name = "Butter", Price=4.50M, Quantity=60, Description="Salted butter sticks"},
                new Product{Id = 9, Name = "Chicken Breast", Price=7.99M, Quantity=90, Description="Boneless chicken breast"},
                new Product{Id = 10, Name = "Ground Beef", Price=6.99M, Quantity=70, Description="1 lb of ground beef"},
                new Product{Id = 11, Name = "Pasta", Price=1.25M, Quantity=200, Description="1 lb of spaghetti pasta"},
                new Product{Id = 12, Name = "Tomato Sauce", Price=2.50M, Quantity=130, Description="Tomato basil pasta sauce"},
                new Product{Id = 13, Name = "Rice", Price=3.00M, Quantity=100, Description="2 lb bag of white rice"},
                new Product{Id = 14, Name = "Beans", Price=2.00M, Quantity=90, Description="1 lb bag of black beans"},
                new Product{Id = 15, Name = "Cereal", Price=3.75M, Quantity=110, Description="Breakfast cereal box"},
                new Product{Id = 16, Name = "Oatmeal", Price=4.00M, Quantity=85, Description="Instant oatmeal packs"},
                new Product{Id = 17, Name = "Yogurt", Price=1.25M, Quantity=160, Description="Greek yogurt cup"},
                new Product{Id = 18, Name = "Orange Juice", Price=4.00M, Quantity=140, Description="1 gallon of orange juice"},
                new Product{Id = 19, Name = "Coffee", Price=8.99M, Quantity=60, Description="1 lb of ground coffee"},
                new Product{Id = 20, Name = "Tea", Price=3.50M, Quantity=120, Description="Box of tea bags"},
                new Product{Id = 21, Name = "Sugar", Price=2.50M, Quantity=110, Description="4 lb bag of sugar"},
                new Product{Id = 22, Name = "Salt", Price=1.00M, Quantity=150, Description="Table salt shaker"},
                new Product{Id = 23, Name = "Pepper", Price=2.00M, Quantity=140, Description="Ground black pepper"},
                new Product{Id = 24, Name = "Olive Oil", Price=6.99M, Quantity=80, Description="1 liter of olive oil"},
                new Product{Id = 25, Name = "Vinegar", Price=2.50M, Quantity=100, Description="1 liter of white vinegar"},
                new Product{Id = 26, Name = "Flour", Price=3.00M, Quantity=90, Description="5 lb bag of all-purpose flour"},
                new Product{Id = 27, Name = "Baking Soda", Price=1.25M, Quantity=70, Description="Baking soda box"},
                new Product{Id = 28, Name = "Baking Powder", Price=2.00M, Quantity=75, Description="Baking powder container"},
                new Product{Id = 29, Name = "Chicken Broth", Price=1.50M, Quantity=130, Description="Chicken broth can"},
                new Product{Id = 30, Name = "Canned Tomatoes", Price=1.25M, Quantity=140, Description="Canned diced tomatoes"}
            }; ;
        }

        public static InventoryServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new InventoryServiceProxy();
                    }
                }
                return instance;
            }
        }





    }
}
