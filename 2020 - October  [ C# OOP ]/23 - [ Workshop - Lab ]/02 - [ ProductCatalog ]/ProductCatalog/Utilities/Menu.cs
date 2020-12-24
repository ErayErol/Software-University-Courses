using ProductCatalog.Pages;
using System;

namespace ProductCatalog.Utilities
{
    public class Menu
    {
        private readonly ProductPage _productPage;
        public Menu(ProductPage productPage)
        {
            this._productPage = productPage;
        }
        public bool MainMenu()
        {
            bool running = true;

            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Products");
                Console.WriteLine("2. Sales");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option...");
                string opt = Console.ReadLine();
                int.TryParse(opt, out option);

            } while (option<1 || option>3);

            switch (option)
            {
                case 1:
                    this._productPage.Show(this);
                    break;
                case 2:
                    break;
                case 3:
                    running = false;
                    break;
                default:
                    break;
            }

            return running;
        }

        public bool ProductMenu()
        {
            bool running = true;
            int option = 0;
            do
            {
                Console.WriteLine("1. List product");
                Console.WriteLine("2. Add product");
                Console.WriteLine("3. Return to Main menu");
                string opt = Console.ReadLine();
                int.TryParse(opt, out option);

            } while (option<1 || option>3);

            switch (option)
            {
                case 1:
                    this._productPage.List();
                    break;
                case 2:
                    this._productPage.Add();
                    break;
                case 3:
                    running = false;
                    break;
                default:
                    break;
            }

            return running;
        }
    }
}
