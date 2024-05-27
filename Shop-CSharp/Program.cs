using Shop_CSharp.Models;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Transactions;

namespace Shop_CSharp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            ShoppingCart cart = new ShoppingCart();
            Inventory inventory = new Inventory();
            Program program = new Program();


            inventory.AddItem("Jorge", "Engenheiro de software", 9.99, 15);
            inventory.AddItem("Betina", "Marketeira", 15.99, 12);

            while (true)
            {
                Console.Write(
                    "\n1) Inventory Management\n" +
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
                            "\n\n1) Add Product\n" +
                            "2) Remove Product\n" +
                            "3) Edit Product\n" +
                            "4) Show Inventory\n" +
                            "5) Go Back\n" +
                            "Select an option: ");

                        Selection = Console.ReadLine();

                        //ADD PRODUCT
                        if (Selection == "1")
                        {
                            //TAKE IN NAME OF PRODUCT
                            Console.Write("\nProduct Name: ");
                            string? name = Console.ReadLine();
                            if (name == null) { name = " "; }

                            //TAKE IN DESCRIPTION OF PRODUCT
                            Console.Write("Description: ");
                            string? description = Console.ReadLine();
                            if (description == null) { description = " "; }

                            //TAKE IN PRICE OF PRODUCT
                            Console.Write("Price: ");
                            string? priceString = Console.ReadLine();
                            if (priceString == null) { priceString = " "; }
                            //LOOP TO GUARANTEE VALID QUANTITY INPUT
                            while (true)
                            {
                                if (program.checkValidDouble(priceString)) { break; }
                                else
                                {
                                    Console.Write("Invalid Input. Try Again: ");
                                    priceString = Console.ReadLine();
                                    if (priceString == null) { priceString = " "; }
                                }
                            }
                            double price = double.Parse(priceString);


                            //TAKE IN QUANTITY OF PRODUCT
                            Console.Write("Quantity: ");
                            string? quantityString = Console.ReadLine();
                            if (quantityString == null) { quantityString = " "; }
                            //LOOP TO GUARANTEE VALID QUANTITY INPUT
                            while (true)
                            {
                                if (program.checkValidInt(quantityString)) { break; }
                                else
                                {
                                    Console.Write("Invalid Input. Try Again: ");
                                    quantityString = Console.ReadLine();
                                    if (quantityString == null) { quantityString = " "; }
                                }
                            }
                            int quantity = int.Parse(quantityString);

                            //ADD PRODUCT TO INVENTORY
                            inventory.AddItem(name, description, price, quantity);
                            Console.WriteLine("Product Added!\n");
                        }

                        //REMOVE PRODUCT
                        else if (Selection == "2")
                        {
                            Console.WriteLine("\nSelect product to be removed");
                            inventory.PrintCatalog();
                            Console.Write("Enter 'X' to cancel deletion.\n" +
                                "ID of product to be deleted: ");
                            string? idString = Console.ReadLine();
                            if(idString == null) {  idString = " "; }
                            if(idString=="X" || idString == "x") { continue; }

                            bool validID = program.checkValidInt(idString);

                            int Id = 0;

                            if(validID) { Id = int.Parse(idString); }

                            //ID STARTS AT 1 SO IT WILL RETURN FALSE IF !VALIDID
                            bool success = inventory.RemoveItem(Id);

                            if (success) { Console.WriteLine("Product Removed!"); }
                            else { Console.WriteLine("Product Not Found, Nothing Removed"); }
                        }

                        //EDIT PRODUCT
                        else if (Selection == "3")
                        {
                            inventory.PrintCatalog();
                            Console.Write("\nEnter 'X' to cancel.\n" +
                                "ID of Product to be edited: ");
                            string? idString = Console.ReadLine();
                            //EXIT IF USER ENTER X
                            if(idString == "X" || idString == "x") { continue; }
                            if(idString == null) { idString = " ";  }



                            //LOOP UNTIL USER ENTERS VALID ID OR CANCELS ACTION
                            while (!inventory.ValidID(idString))
                            {
                                Console.Write("Invalid Input. Try Again: ");
                                idString = Console.ReadLine();
                                if (idString == null) { idString = " "; }

                                if (idString == "X" || idString == "x") { break; }

                            }
                            if(idString == "X" || idString == "x") { continue; }

                            int Id = int.Parse(idString);


                            while (idString != "x" || idString != "X")
                            { 
                                Console.Write(
                                    "\n1) Edit Name\n" +
                                    "2) Edit Description\n" +
                                    "3) Edit Price\n" +
                                    "4) Edit Quantity\n" +
                                    "5) Go Back\n" +
                                    "Select an option: ");

                                Selection = Console.ReadLine();

                                while (Selection != "1" && Selection != "2" && Selection != "3" && Selection != "4" && Selection != "5")
                                {
                                    Console.Write("Invalid Option. Try Again");
                                    Selection = Console.ReadLine();
                                }

                                if (Selection == "1")
                                {
                                    Console.Write("\nEnter the new name: ");
                                    string? newName = Console.ReadLine();
                                    if (newName == null) { newName = " "; }

                                    inventory.EditName(Id, newName);
                                }
                                else if (Selection == "2")
                                {
                                    Console.Write("\nEnter the new description: ");
                                    string? newDescription = Console.ReadLine();
                                    if (newDescription == null) { newDescription = " "; }

                                    inventory.EditDescription(Id, newDescription);
                                }
                                else if (Selection == "3")
                                {
                                    //TAKE IN PRICE OF PRODUCT
                                    Console.Write("\nEnter the new price: ");
                                    string? priceString = Console.ReadLine();
                                    if (priceString == null) { priceString = " "; }
                                    
                                    //LOOP TO GUARANTEE VALID QUANTITY INPUT
                                    while (true)
                                    {
                                        if (program.checkValidDouble(priceString)) { break; }
                                        else
                                        {
                                            Console.Write("Invalid Input. Try Again: ");
                                            priceString = Console.ReadLine();
                                            if (priceString == null) { priceString = " "; }
                                        }
                                    }

                                    double newPrice = double.Parse(priceString);
                                    inventory.EditPrice(Id, newPrice);
                                }

                                else if (Selection == "4")
                                {
                                    //TAKE IN QUANTITY OF PRODUCT
                                    Console.Write("\nEnter the new quantity: ");
                                    string? quantityString = Console.ReadLine();
                                    if (quantityString == null) { quantityString = " "; }

                                    //LOOP TO GUARANTEE VALID QUANTITY INPUT
                                    while (true)
                                    {
                                        if (program.checkValidInt(quantityString)) { break; }
                                        else
                                        {
                                            Console.Write("Invalid Input. Try Again: ");
                                            quantityString = Console.ReadLine();
                                            if (quantityString == null) { quantityString = " "; }
                                        }
                                    }

                                    int newQuantity = int.Parse(quantityString);

                                    inventory.EditQuantity(Id, newQuantity);
                                }
                                else if (Selection == "5")
                                {
                                    break;
                                }

                            }

                        }

                        //SHOW INVENTORY
                        else if (Selection == "4")
                        {
                            Console.WriteLine("\n");
                            inventory.PrintCatalog();
                        }

                        //EXIT
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
                    Console.WriteLine("\nWelcome To The Shop!");

                    while (true)
                    {
                        Console.Write(
                            "\n1) Add Product to Shopping Cart\n" +
                            "2) Remove Product from Shopping Cart\n" +
                            "3) Show Shopping Cart\n" +
                            "4) Checkout\n" +
                            "5) Go Back\n" +
                            "Select an option: ");
                        Selection = Console.ReadLine();

                        if (Selection == "1")
                        {
                            inventory.PrintCatalog();

                            Console.Write("\nEnter ID of product to add to cart: ");
                            string? stringID = Console.ReadLine();
                            if (stringID == null) { stringID = " "; }

                            while (!inventory.ValidID(stringID))
                            {
                                Console.Write("Invalid Input. Try Again: ");
                                stringID = Console.ReadLine();
                                if (stringID == null) { stringID = " "; }
                            }

                            int ID = int.Parse(stringID);

                            Console.Write("How many would you like to add to cart?: ");
                            string? quantityString = Console.ReadLine();
                            if(quantityString == null) {  quantityString = " "; }

                            while (!inventory.ValidQuantity(ID, quantityString))
                            {
                                Console.Write("Invalid Input. Try Again: ");
                                quantityString = Console.ReadLine();
                                if (quantityString == null) { quantityString = " "; }
                            }

                            int quantity = int.Parse(quantityString);

                            cart.AddToCart(ID, quantity, inventory);

                        }

                        else if (Selection == "2")
                        {
                            cart.PrintCart();

                            Console.Write("\nEnter ID of product to remove from the cart: ");
                            string? stringID = Console.ReadLine();
                            if (stringID == null) { stringID = " "; }

                            while (!cart.ValidID(stringID))
                            {
                                Console.Write("Invalid Input. Try Again: ");
                                stringID = Console.ReadLine();
                                if (stringID == null) { stringID = " "; }
                            }

                            int ID = int.Parse(stringID);

                            Console.Write("How many would you like to remove from the cart?: ");
                            string? quantityString = Console.ReadLine();
                            if (quantityString == null) { quantityString = " "; }

                            while (!cart.ValidQuantity(ID, quantityString))
                            {
                                Console.Write("Invalid Input. Try Again: ");
                                quantityString = Console.ReadLine();
                                if (quantityString == null) { quantityString = " "; }
                            }

                            int quantity = int.Parse(quantityString);

                            cart.RemoveFromCart(ID, quantity);

                        }

                        else if (Selection == "3")
                        {
                            Console.WriteLine("\n");
                            cart.PrintCart();
                            Console.WriteLine($"Total Price Before Tax: ${Math.Round(cart.CalculateTotal(), 2)}");
                        }

                        else if (Selection == "4")
                        {
                            Console.WriteLine("\n");
                            cart.PrintCart();
                            Console.WriteLine($"Total Price with Tax: ${Math.Round(cart.CalculateTotal() * 1.07, 2)}");

                            Console.Write("\nEnter 'X' to return to shop." +
                                "Enter 'Y' to checkout: ");
                            
                            string? input = Console.ReadLine();
                            if (input == null) { input = " "; }

                            while (input != "X" && input != "Y" && input != "x" && input != "y")
                            {
                                Console.Write("Invalid Input. Try Again:");
                                input = Console.ReadLine();
                                if (input == null) { input = " "; }
                            }

                            if(input == "X" || input == "x")
                            { continue; }

                            else
                            {
                                Console.WriteLine("\nCheckout Successful\n" +
                                    $"Total Price: ${Math.Round(cart.CalculateTotal() * 1.07, 2)}");

                                cart = new ShoppingCart();
                            }

                        }

                        else if (Selection == "5")
                        { break; }

                        else
                        {
                            Console.WriteLine("Invalid Option. Try Again");
                        }
                    }
                }

                if (Selection == "3")
                { break; }

            }
        }

        //RETURN TRUE IF STRING IS AN INT >= 0
        public bool checkValidInt(string s)
        {
            if (!int.TryParse(s, out int num)) { return false; }

            int i = int.Parse(s);

            if (i < 0) { return false; }

            return true;
        }

        //RETURN TRUE IF STRING IS AN INT >= 0
        public bool checkValidDouble(string s)
        {
            if (!double.TryParse(s, out double num)) { return false; }

            double i = double.Parse(s);

            if (i < 0) { return false; }

            return true;
        }
    }
}
