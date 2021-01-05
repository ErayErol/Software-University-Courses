using ConsoleTables;

using ProductCatalog.Core.Contracts;
using ProductCatalog.Infrastucture.Data.Model;
using ProductCatalog.Utilities;
using System;

namespace ProductCatalog.Pages
{
    public class ProductPage
    {
        private readonly IProductService _productService;
        public ProductPage(IProductService productService)
        {
            this._productService = productService;
        }

        public void Show(Menu menu)
        {
            bool running = true;
            while (running)
            {
                running = menu.ProductMenu();
            }
        }

        public void List()
        {
            var products = this._productService.GetProducts();

            ConsoleTable.From(products)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write();
        }

        public void Add()
        {
           Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            string quantity = Console.ReadLine();
            Console.Write("Price: ");
           string price = Console.ReadLine();

            try
            {
                Product product = new Product()
                {
                    Name = name,
                    Quantity = int.Parse(quantity),
                    Price = decimal.Parse(price)

                };
                this._productService.Save(product);

                Console.WriteLine("Product added successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("Product not added");
            }
        }
    }
}
