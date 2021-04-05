namespace ProductShop
{
    using ProductShop.Data;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var result = GetUsersWithProducts(context);
            File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var allUsers = context
                .Users
                .AsEnumerable() // this is for judge
                .Where(x => x.ProductsSold.Count > 0)
                .OrderByDescending(x => x.ProductsSold.Count)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    x.ProductsSold.Count,
                    SoldProducts = x.ProductsSold
                        .Select(ps => new
                        {
                            ps.Name,
                            ps.Price
                        })
                        .OrderByDescending(s => s.Price)
                })
                .ToList();

            var users = allUsers.Take(10).ToList();

            XDocument doc = new XDocument();

            XElement rootElement = new XElement("Users");
            doc.Add(rootElement);
            
            XElement allUsersCountElement = new XElement("count", allUsers.Count);
            doc.Root.Add(allUsersCountElement);

            XElement usersElement = new XElement("users");
            foreach (var user in users)
            {
                XElement userElement = new XElement("User");
                XElement firstNameElement = new XElement("firstName", user.FirstName);
                XElement lastNameElement = new XElement("lastName", user.LastName);
                XElement ageElement = new XElement("age", user.Age);
                userElement.Add(firstNameElement, lastNameElement, ageElement);

                XElement soldProductElement = new XElement("SoldProducts");
                XElement countOfSoldProductsElement = new XElement("count", user.Count);
                soldProductElement.Add(countOfSoldProductsElement);

                XElement productsElement = new XElement("products");
                foreach (var soldProduct in user.SoldProducts)
                {
                    XElement productElement = new XElement("Product");
                    XElement nameElement = new XElement("name", soldProduct.Name);
                    XElement priceElement = new XElement("price", soldProduct.Price);
                    productElement.Add(nameElement, priceElement);

                    productsElement.Add(productElement);
                }
                soldProductElement.Add(productsElement);
                userElement.Add(soldProductElement);
                usersElement.Add(userElement);
            }

            doc.Root.Add(usersElement);
            return doc.ToString();
        }
    }
}