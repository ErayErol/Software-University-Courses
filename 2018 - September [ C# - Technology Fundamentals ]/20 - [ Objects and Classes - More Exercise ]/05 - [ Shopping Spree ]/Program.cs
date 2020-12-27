using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console
                .ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var products = Console
                .ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var peopleList = new List<Person>();

            for (int i = 0; i < people.Count; i += 2)
            {
                string name = people[i];
                double peopleMoney = double.Parse(people[i + 1]);

                string productName = products[i];
                double productCost = double.Parse(products[i + 1]);

                Product product = new Product(productName, productCost);
                Person person = new Person(name, peopleMoney, product);

                peopleList.Add(person);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var splitedInput = input
                    .Split()
                    .ToList();

                string name = splitedInput[0];
                string product = splitedInput[1];

                foreach (var item in peopleList)
                {
                    if (item.Name == name)
                    {
                        double currentBalance = item.Money;

                        foreach (var item1 in peopleList)
                        {
                            if (item1.BagOfProducts.Name == product)
                            {
                                if (currentBalance >= item1.BagOfProducts.Cost)
                                {
                                    Console.WriteLine($"{item.Name} bought {item1.BagOfProducts.Name}");
                                    item.Money -= item1.BagOfProducts.Cost;
                                    item.ProductsBought.Add(product);
                                }
                                else
                                {
                                    Console.WriteLine($"{item.Name} can't afford {item1.BagOfProducts.Name}");
                                }
                            }
                        }
                    }
                }
            }

            foreach (var item in peopleList)
            {
                if (item.ProductsBought.Count >= 1)
                {
                    Console.WriteLine($"{item.Name} - {string.Join(", ", item.ProductsBought)}");
                }
                else
                {
                    Console.WriteLine($"{item.Name} - Nothing bought");
                }
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double Money { get; set; }
        public Product BagOfProducts { get; set; }

        public List<string> ProductsBought { get; set; } = new List<string>();

        public Person(string name, double money, Product bagOfProducts)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = bagOfProducts;
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
    }
}
