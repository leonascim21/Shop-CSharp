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
            ShoppingCart Cart = new ShoppingCart();
            Inventory inventory = new Inventory();

            ////////////////////////////
            //FOR TESTING DELETE LATER//
            ////////////////////////////
            inventory.AddItem("Apple", "A fresh red apple", 0.99, 50);
            inventory.AddItem("Banana", "A ripe yellow banana", 0.59, 30);
            inventory.AddItem("Orange", "A juicy orange", 1.29, 20);
            inventory.AddItem("Grapes", "A bunch of seedless grapes", 2.99, 15);
            inventory.AddItem("Strawberry", "A box of fresh strawberries", 3.49, 25);
            inventory.AddItem("Blueberry", "A pint of blueberries", 4.99, 10);
            inventory.AddItem("Pineapple", "A tropical pineapple", 2.99, 5);
            inventory.AddItem("Mango", "A ripe mango", 1.49, 12);
            inventory.AddItem("Watermelon", "A large watermelon", 5.99, 8);
            inventory.AddItem("Peach", "A sweet peach", 1.79, 20);
            inventory.AddItem("Plum", "A juicy plum", 0.99, 18);
            inventory.AddItem("Kiwi", "A tangy kiwi fruit", 0.69, 25);
            inventory.AddItem("Pear", "A crisp pear", 1.09, 30);
            inventory.AddItem("Avocado", "A creamy avocado", 1.99, 12);
            inventory.AddItem("Cherry", "A bag of cherries", 3.99, 8);
            inventory.AddItem("Pomegranate", "A pomegranate fruit", 2.49, 5);
            inventory.AddItem("Lemon", "A fresh lemon", 0.49, 40);
            inventory.AddItem("Lime", "A tangy lime", 0.39, 35);
            inventory.AddItem("Coconut", "A fresh coconut", 2.79, 7);
            inventory.AddItem("Papaya", "A ripe papaya", 3.99, 6);
            inventory.AddItem("Dragon Fruit", "An exotic dragon fruit", 4.49, 3);
            inventory.AddItem("Passion Fruit", "A tropical passion fruit", 2.99, 10);
            inventory.AddItem("Cantaloupe", "A juicy cantaloupe", 3.49, 9);
            inventory.AddItem("Honeydew", "A sweet honeydew melon", 3.89, 11);
            inventory.AddItem("Blackberry", "A box of blackberries", 4.29, 15);
            inventory.AddItem("Raspberry", "A pint of raspberries", 4.99, 10);
            inventory.AddItem("Cranberry", "A bag of cranberries", 3.69, 8);
            inventory.AddItem("Fig", "A pack of figs", 2.89, 12);
            inventory.AddItem("Date", "A box of dates", 5.99, 7);
            inventory.AddItem("Apricot", "A fresh apricot", 1.49, 18);
            inventory.AddItem("Lychee", "A bunch of lychees", 3.29, 20);
            inventory.AddItem("Guava", "A tropical guava", 2.59, 10);
            inventory.AddItem("Star Fruit", "An exotic star fruit", 3.99, 5);
            inventory.AddItem("Persimmon", "A ripe persimmon", 2.29, 8);
            inventory.AddItem("Mulberry", "A box of mulberries", 4.49, 7);
            inventory.AddItem("Gooseberry", "A pint of gooseberries", 3.89, 9);
            inventory.AddItem("Tangerine", "A sweet tangerine", 1.29, 25);
            inventory.AddItem("Clementine", "A box of clementines", 4.99, 15);
            inventory.AddItem("Nectarine", "A juicy nectarine", 1.79, 20);
            inventory.AddItem("Pineberries", "A box of pineberries", 5.49, 5);
            /////////////////////////////////////////////////////////////////////





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
                            "1) Add Product\n" +
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
                            Console.Write("Name: ");
                            string? name = Console.ReadLine();
                            if (name == null) { name = " "; }

                            //TAKE IN DESCRIPTION OF PRODUCT
                            Console.Write("Description: ");
                            string? description = Console.ReadLine();
                            if (description == null) { description = " "; }

                            //TAKE IN PRICE OF PRODUCT
                            Console.Write("Price: ");
                            string? priceString = Console.ReadLine();
                            bool validPrice = false;
                            double price = 0;
                            //LOOP TO GUARANTEE PRICE IS VALID
                            while (!validPrice)
                            {
                                //IF PARSE FAILS, REQUEST NEW INPUT 
                                while (!double.TryParse(priceString, out double num))
                                {
                                    Console.Write("Invalid Price, Try Again: ");
                                    priceString = Console.ReadLine();
                                }
                                //IF INPUT IS A DOUBLE CHECK IF GREATER THAN 0, IF NOT LOOP AGAIN
                                price = double.Parse(priceString);
                                if (price >= 0)
                                { validPrice = true; }
                                else { priceString = "A"; } //SET STRING TO NON INTEGER SO PROMPTS ANOTHER INPUT
                            }

                            //TAKE IN QUANTITY OF PRODUCT
                            Console.Write("Quantity: ");
                            string? quantityString = Console.ReadLine();
                            bool validQuantity = false;
                            int quantity = 0;

                            //LOOP TO GUARANTEE QUANTITY IS VALID
                            while (!validQuantity)
                            {
                                //IF PARSE FAILS, REQUEST NEW INPUT 
                                while (!int.TryParse(quantityString, out int num))
                                {
                                    Console.Write("Invalid Quantity, Try Again: ");
                                    quantityString = Console.ReadLine();
                                }
                                //IF INPUT IS AN INTEGER CHECK IF GREATER THAN 0, IF NOT LOOP AGAIN
                                quantity = int.Parse(quantityString);
                                if (quantity >= 0)
                                { validQuantity = true; }
                                else { quantityString = "A"; } //SET STRING TO NON INTEGER SO PROMPTS ANOTHER INPUT
                            }

                            //ADD PRODUCT TO INVENTORY
                            inventory.AddItem(name, description, price, quantity);
                            Console.WriteLine("Product Added!\n");
                        }

                        //REMOVE PRODUCT
                        else if (Selection == "2")
                        {
                            Console.WriteLine("Select product to be removed");
                            inventory.PrintNames();
                            Console.Write("Enter 'X' to cancel deletion.\n" +
                                "ID of product to be deleted: ");

                            bool validID = false, cancel = false;
                            int Id = 0;

                            //LOOP UNTIL USER ENTERS VALID ID OR CANCELS ACTION
                            while (!validID)
                            {
                                string? idString = Console.ReadLine();
                                //IF PARSE FAILS, REQUEST NEW INPUT
                                while (!int.TryParse(idString, out int num))
                                {
                                    //CANCEL IF USER INPUTS X
                                    if (idString == "X")
                                    {
                                        cancel = true;
                                        break;
                                    }

                                    Console.WriteLine("Invalid Input. ID must be an integer.");
                                    Console.Write("ID of Product to be deleted:");
                                    idString = Console.ReadLine();

                                }

                                //EXIT LOOP
                                if (cancel)
                                    break;

                                Id = int.Parse(idString);
                                validID = true;
                            }

                            bool success = inventory.RemoveItem(Id);

                            if (success) { Console.WriteLine("Product Removed!"); }
                            else { Console.WriteLine("Product Not Found, Nothing Removed"); }
                        }

                        //EDIT PRODUCT
                        else if (Selection == "3")
                        {
                            inventory.Print();
                            Console.Write("ID of Product to be edited: ");
                            string? idString = Console.ReadLine();

                            bool cancel = false;
                            int Id = 0;

                            //LOOP UNTIL USER ENTERS VALID ID OR CANCELS ACTION
                            while (!inventory.ValidID(Id))
                            {
                                //IF PARSE FAILS, REQUEST NEW INPUT
                                while (!int.TryParse(idString, out int num))
                                {
                                    //CANCEL IF USER INPUTS X
                                    if (idString == "X")
                                    {
                                        cancel = true;
                                        break;
                                    }

                                    Console.WriteLine("Invalid Input. Try Again.");
                                    Console.Write("ID of Product to be edited: ");
                                    idString = Console.ReadLine();

                                }

                                //EXIT LOOP
                                if (cancel)
                                    break;

                                Id = int.Parse(idString);
                                idString = "A";
                            }


                            while (true)
                            { 
                                Console.Write(
                                    "1) Edit Name\n" +
                                    "2) Edit Description\n" +
                                    "3) Edit Price\n" +
                                    "4) Edit Quantity\n" +
                                    "5) Go Back" +
                                    "Select an option: ");

                                Selection = Console.ReadLine();

                                while (Selection != "1" && Selection != "2" && Selection != "3" && Selection != "4" && Selection != "5")
                                {
                                    Console.Write("Invalid Option. Try Again");
                                    Selection = Console.ReadLine();
                                }

                                if (Selection == "1")
                                {
                                    Console.Write("Enter the new name: ");
                                    string? newName = Console.ReadLine();
                                    if (newName == null) { newName = " "; }

                                    inventory.EditName(Id, newName);
                                }
                                else if (Selection == "2")
                                {
                                    Console.Write("Enter the new description: ");
                                    string? newDescription = Console.ReadLine();
                                    if (newDescription == null) { newDescription = " "; }

                                    inventory.EditDescription(Id, newDescription);
                                }
                                else if (Selection == "3")
                                {
                                    //TAKE IN PRICE OF PRODUCT
                                    Console.Write("Enter the new price: ");
                                    string? priceString = Console.ReadLine();
                                    bool validPrice = false;
                                    double newPrice = 0;
                                    //LOOP TO GUARANTEE PRICE IS VALID
                                    while (!validPrice)
                                    {
                                        //IF PARSE FAILS, REQUEST NEW INPUT 
                                        while (!double.TryParse(priceString, out double num))
                                        {
                                            Console.Write("Invalid Price, Try Again: ");
                                            priceString = Console.ReadLine();
                                        }
                                        //IF INPUT IS A DOUBLE CHECK IF GREATER THAN 0, IF NOT LOOP AGAIN
                                        newPrice = double.Parse(priceString);
                                        if (newPrice >= 0)
                                        { validPrice = true; }
                                        else { priceString = "A"; } //SET STRING TO NON INTEGER SO PROMPTS ANOTHER INPUT
                                    }

                                    inventory.EditPrice(Id, newPrice);
                                }
                                else if (Selection == "4")
                                {
                                    //TAKE IN QUANTITY OF PRODUCT
                                    Console.Write("Enter the new quantity: ");
                                    string? quantityString = Console.ReadLine();
                                    bool validQuantity = false;
                                    int newQuantity = 0;

                                    //LOOP TO GUARANTEE QUANTITY IS VALID
                                    while (!validQuantity)
                                    {
                                        //IF PARSE FAILS, REQUEST NEW INPUT 
                                        while (!int.TryParse(quantityString, out int num))
                                        {
                                            Console.Write("Invalid Quantity, Try Again: ");
                                            quantityString = Console.ReadLine();
                                        }
                                        //IF INPUT IS AN INTEGER CHECK IF GREATER THAN 0, IF NOT LOOP AGAIN
                                        newQuantity = int.Parse(quantityString);
                                        if (newQuantity >= 0)
                                        { validQuantity = true; }
                                        else { quantityString = "A"; } //SET STRING TO NON INTEGER SO PROMPTS ANOTHER INPUT
                                    }

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
                            inventory.Print();
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
                            Console.WriteLine("Invalid Option. Try Again");
                        }
                    }
                }

                if (Selection == "3")
                { break; }

            }
        }
    }
}
