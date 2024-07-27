using Shop.Library.Models;
using Shop_CSharp.Models;

namespace Shop.API.Database
{
    public static class FakeDatabase
    {
        static FakeDatabase()
        {
            ShoppingCarts = new List<ShoppingCart>();
            ShoppingCarts.Add(new ShoppingCart("Shopping Cart", 1));
        } 

        public static List<ShoppingCart> ShoppingCarts { get; }

        public static int NextCartId
        {
            get
            {
                if (!ShoppingCarts.Any())
                {
                    return 1;
                }

                return ShoppingCarts.Select(p => p.Id).Max() + 1;
            }
        }
    }
}
