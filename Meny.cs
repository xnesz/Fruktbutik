using System;

namespace Meny
{
    class Menu
    {
        Produkt[] StartArray;
        string[] MenuOptions = { "1. Browse all Products. ", "2. Admin Login.", "3. Exit program." };
        string[] AdminOptions = { "4. Add Product", "5. Edit Product", "6. Remove Product " };
        private bool AdminStatus = false;
        string Choice;
        Produkter produkter = new Produkter();

        public Menu()
        {
            StartArray = produkter.CreateFirstTenProducts();
        }

        // Använd DisplayMenu() för att komma tillbaka till första menyn och börja "om"
        // Den kommer ihåg om du är admin eller inte
        //Login är admin - password. Alla små bokstäver

        public void DisplayMenu()
        {

            Console.WriteLine("Enter appropriate choice and press enter.");
            while (true)
            {
                if (AdminStatus == false)
                {
                    for (int i = 0; i < MenuOptions.Length; i++)
                    {
                        Console.WriteLine(MenuOptions[i]);


                    }
                    Choice = Console.ReadLine();
                    HandleInput(Choice);
                }

                else if (AdminStatus == true)
                {
                    for (int i = 0; i < MenuOptions.Length; i++)
                    {
                        Console.WriteLine(MenuOptions[i]);

                    }
                    for (int j = 0; j < AdminOptions.Length; j++)
                    {
                        Console.WriteLine(AdminOptions[j]);
                    }
                    Choice = Console.ReadLine();
                    HandleInput(Choice);

                }
            }
        }

        // --------------- Used for Handle input ---------------------//
        string[] allFruitsPurchased = new string[100];
        int[] howManyOfEachFruit = new int[100];
        int[] priceOneFruitPurchase = new int[100];
        int fruitPurchasesCount = 0;
        int priceOneFruit = 0;
        int PriceOneFruitCount = 0;
        double totalPrice = 0;
        int eachFruitCount = 0;

        //Här är alla Meny val. Här lägger vi till fler val i huvudmenyn om det behövs

        public void HandleInput(string Choice)
        {
            int x = 0, buyAmount = 0, checkoutOrMore = 0;

            string whichFruit = "";

            if (Choice == "2")
            {
                CheckAdminName();
            }

            else if (Choice == "1")
            {
                Console.Clear();

                produkter.GetFullArray(StartArray);

                Console.WriteLine("Which fruit you want to buy? Select using the numbers from the list");
                Console.WriteLine();
                x = int.Parse(Console.ReadLine());

                if(x-1 >= StartArray.Length)
                {
                    Console.WriteLine("Product id does not exist");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    HandleInput("1");
                    return;
                }
                
                whichFruit = Produkt.GetProductName(StartArray, x - 1);
                allFruitsPurchased[fruitPurchasesCount] = whichFruit;
                fruitPurchasesCount = fruitPurchasesCount + 1;

                Console.WriteLine("How many fruits do you want to buy?");
                buyAmount = int.Parse(Console.ReadLine());
                priceOneFruit = buyAmount * Produkt.GetProductPrice(StartArray, x - 1);
                totalPrice = totalPrice + buyAmount * Produkt.GetProductPrice(StartArray, x - 1);
                Console.WriteLine($"\nTotal price is {totalPrice}kr.");
                howManyOfEachFruit[eachFruitCount] = buyAmount;
                eachFruitCount++;

                priceOneFruitPurchase[PriceOneFruitCount] = priceOneFruit;
                PriceOneFruitCount++;

                Console.WriteLine("\nType 1: For checkout 2: for more fruits/vegetables. ");
                checkoutOrMore = int.Parse(Console.ReadLine());

                if (checkoutOrMore == 2)
                {
                    HandleInput("1");
                }

                if (checkoutOrMore == 1)
                {
                    Console.Clear();
                    //Console.WriteLine($"\nYou bought {buyAmount} {whiceFruit} Total price is:{totalPrice}kr");

                    for (int i = 0; i < fruitPurchasesCount; i++)
                    {
                        Console.WriteLine("\nYou chose: " + allFruitsPurchased[i] + " and bought " +
                            howManyOfEachFruit[i] + " of " + allFruitsPurchased[i] + " for the price of: "
                            + priceOneFruitPurchase[i] + "kr.");
                    }

                    Console.WriteLine($"\nTotal price is {totalPrice}kr.");
                    Console.WriteLine("\nThank you for shopping at fruktbutik.se");
                    Console.WriteLine($"\n \n\n Type 1: if you want to return to main menu, or type 2 to exit");
                    checkoutOrMore = int.Parse(Console.ReadLine());
                }
                if (checkoutOrMore == 1)
                {
                    DisplayMenu();
                }

                else if (checkoutOrMore == 2)
                {
                    Environment.Exit(0);
                }
            }

            else if (Choice == "3")
            {
                // Environment.Exit(0) avslutar programmet
                Environment.Exit(0);
            }
            else if (Choice == "4" && AdminStatus == true)
            {
                //string input = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter a name for new product");
                string prodname = Console.ReadLine();
                Console.WriteLine("Enter Description of your new product");
                string des = Console.ReadLine();
                Console.WriteLine("Enter Price");
                int price = Convert.ToInt32(Console.ReadLine());

                StartArray = produkter.AddNewItem(StartArray, prodname, des, price);
                produkter.GetFullArray(StartArray);
            }
            else if (Choice == "5" && AdminStatus == true)
            {
                //Här får vi lägga in kod för 5. Edit Product 

                //Borde gå att lösa genom att använda våra Set funktioner ifrån Produkter klassen
            }
            else if (Choice == "6" && AdminStatus == true)
            {
                //Här får vi lägga in kod för 6. Remove Product

                //Får skapa ny metod i produkt klassen som vi kallar på här.
            }
            else if (Convert.ToInt32(Choice) > MenuOptions.Length && AdminStatus == false)
            {
                Console.WriteLine($"You have to choose a number between 1 and {MenuOptions.Length}.");
            }
            else if (Convert.ToInt32(Choice) > MenuOptions.Length + AdminOptions.Length && AdminStatus == true)
            {
                Console.WriteLine($"You have to choose a number between 1 and {MenuOptions.Length + AdminOptions.Length}.");
            }
            else
            {
                Console.WriteLine("Wrong input - Try again");
            }
        }

        // Detta är metoden som kräver admin inlogg för att sedan spara det tills programmet stängs av.
        //Login är "admin" och "password". Alla små bokstäver
        private bool CheckAdminName()
        {
            Console.Clear();
            Console.WriteLine("Enter admin login:");
            string LoginName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string Password = Console.ReadLine();
            Console.Clear();
            while (AdminStatus == false)
            {
                if (Password == "password" && LoginName == "admin")
                {
                    AdminStatus = true;
                    Console.WriteLine("You are now logged in!");
                    Console.WriteLine("Admin access granted\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong login information");
                    Console.WriteLine("Enter admin login:");
                    LoginName = Console.ReadLine();

                    Console.WriteLine("Enter Password:");
                    Password = Console.ReadLine();
                    Console.Clear();
                }
            }
            return AdminStatus;
        }

        //Denna används inte, kan användas om vi vill ha ett meny val som lägger till fler val i huvudmenyn inne i programmet.
        //Kanske slutar med att vi tar bort den
        public void AddOption()
        {
            Console.WriteLine("You chose to add another option.");
            Console.WriteLine("Enter new info: ");
            string option = Console.ReadLine();

            string[] TempArray = new string[MenuOptions.Length + 1];

            for (int i = 0; i < MenuOptions.Length; i++)
            {
                TempArray[i] = MenuOptions[i];
            }

            TempArray[TempArray.Length - 1] = option;
            MenuOptions = TempArray;
        }
    }
}