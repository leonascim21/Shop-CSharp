using Shop_CSharp.Models;

namespace Shop_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            ShoppingCart Cart = new ShoppingCart();
            Inventory inventory = new Inventory();

            while (true)
            {
                Console.Write(
                    "1) Inventory Management\n" +
                    "2) Shop\n" +
                    "3) Exit\n" +
                    "Select an option: ");

                string? Selection = Console.ReadLine();

                while (Selection != "1" && Selection != "2" && Selection != "3")
                {
                    Console.Write("Invalid Option. Try Again: ");
                    Selection = Console.ReadLine();
                }

                if (Selection == "1")
                {

                    while (true)
                    {
                        Selection = "0";
                        Console.Write(
                            "1) Add Item\n" +
                            "2) Remove Item\n" +
                            "3) Edit Item\n" +
                            "4) Show Inventory\n" +
                            "5) Go Back\n" +
                            "Select an option: ");

                        Selection = Console.ReadLine();

                        if (Selection == "1")
                        {
                            Console.Write("Name: ");
                            string? name = Console.ReadLine();
                            if (name == null) { name = " "; }

                            Console.Write("Description: ");
                            string? description = Console.ReadLine();
                            if (description == null) { description = " "; }

                            Console.Write("Price: ");
                            string? priceString = Console.ReadLine();
                            bool validPrice = false;
                            double price = 0;
                            while (!validPrice)
                            {
                                while (!double.TryParse(priceString, out double num))
                                {
                                    Console.Write("Invalid Price, Try Again: ");
                                    priceString = Console.ReadLine();
                                }
                                price = double.Parse(priceString);
                                if (price >= 0)
                                { validPrice = true; }
                                else { priceString = "A"; } //SET STRING TO NON INTEGER SO PROMPTS ANOTHER INPUT
                            }

                            Console.Write("Quantity: ");
                            string? quantityString = Console.ReadLine();
                            bool validQuantity = false;
                            int quantity = 0;

                            while (!validQuantity)
                            {
                                while (!int.TryParse(quantityString, out int num))
                                {
                                    Console.Write("Invalid Quantity, Try Again: ");
                                    quantityString = Console.ReadLine();
                                }
                                quantity = int.Parse(quantityString);
                                if (quantity >= 0)
                                { validQuantity = true; }
                                else { quantityString = "A"; } //SET STRING TO NON INTEGER SO PROMPTS ANOTHER INPUT
                            }

                            inventory.AddItem(name, description, price, quantity);
                            Console.WriteLine("Product Added!\n");
                        }


                        else if (Selection == "2")
                        {
                            Console.WriteLine("Select product to be removed");
                            inventory.PrintNames();
                            Console.Write("ID of Item to be deleted: ");

                            bool validID = false;
                            int Id = 0;

                            while (!validID)
                            {
                                string? idString = Console.ReadLine();
                                if (!int.TryParse(idString, out int num))
                                {
                                    Console.WriteLine("Invalid Input. ID must be an integer.");
                                    Console.Write("ID of Item to be deleted:");
                                    idString = Console.ReadLine();
                                }

                                Id = int.Parse(idString);
                                validID = true;
                            }

                            bool success = inventory.RemoveItem(Id);

                            if (success) { Console.WriteLine("Item Removed!"); }
                            else { Console.WriteLine("Item Not Found, Nothing Removed"); }

                        }


                        else if (Selection == "3")
                        {
                            //FALTA AQUI
                        }


                        else if (Selection == "4")
                        {
                            inventory.Print();
                        }


                        else if (Selection == "5")
                        { break; }

                        else
                        {
                            Console.Write("Invalid Option. Try Again");
                        }
                    }
                }

                if (Selection == "2")
                {
                    Console.WriteLine("Welcome To The Shop!");

                    while (true)
                    {
                        Console.Write(
                            "1) Add Product to Shopping Cart\n" +
                            "2) Remove Product from Shopping Cart\n" +
                            "3) Show Shopping Cart\n" +
                            "4) Checkout\n" +
                            "5) Go Back\n" +
                            "Select an option: ");
                        Selection = Console.ReadLine();

                        if (Selection == "1")
                        {
                            inventory.PrintCatalog();

                        }

                        else if (Selection == "2")
                        {

                        }

                        else if (Selection == "3")
                        {

                        }

                        else if (Selection == "4")
                        {

                        }

                        else if (Selection == "5")
                        { break; }

                        else
                        {
                            Console.Write("Invalid Option. Try Again");
                        }
                    }
                }

                if (Selection == "3")
                { break; }

            }
        }
    }
}
