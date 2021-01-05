using System.Linq;

namespace INStock
{
    using Contracts;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class ProductStock : IProductStock
    {
        private readonly HashSet<string> productLabels;
        private readonly List<IProduct> productsByIndex;
        private readonly Dictionary<string, IProduct> productsByLabel;
        private readonly Dictionary<int, List<IProduct>> productsByQuantity;
        private readonly SortedDictionary<decimal, List<IProduct>> productsSortedByPrice;

        public ProductStock()
        {
            this.productLabels = new HashSet<string>();
            this.productsByIndex = new List<IProduct>();
            this.productsByLabel = new Dictionary<string, IProduct>();
            this.productsByQuantity = new Dictionary<int, List<IProduct>>();
            this.productsSortedByPrice = new SortedDictionary<decimal, List<IProduct>>
                (Comparer<decimal>
                .Create((x, y)
                => y.CompareTo(x)));
        }

        public void Add(IProduct product)
        {
            this.ValidateNullProduct(product);

            if (productLabels.Contains(product.Label))
            {
                throw new ArgumentException($"A product with {product.Label} label already exist.");
            }

            this.InitializeCollection(product);

            this.productLabels.Add(product.Label);
            this.productsByIndex.Add(product);
            this.productsByLabel[product.Label] = product;
            this.productsByQuantity[product.Quantity].Add(product);
            this.productsSortedByPrice[product.Price].Add(product);
        }

        public bool Contains(IProduct product)
        {
            this.ValidateNullProduct(product);

            return this.productLabels.Contains(product.Label);
        }

        public int Count
            => this.productsByIndex.Count;

        public IProduct Find(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Product index cannot be negative.");
            }

            if (index >= this.productsByIndex.Count)
            {
                throw new IndexOutOfRangeException("Doesn't exist product with this index.");
            }

            return this.productsByIndex[index];
        }

        public IProduct FindByLabel(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException("Product label cannot be null.");
            }

            if (this.productsByLabel.ContainsKey(label) == false)
            {
                throw new ArgumentException($"Product with {label} label does not exist in stock.");
            }

            return this.productsByLabel[label];
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            var result = new List<IProduct>();

            foreach (var (price, products) in productsSortedByPrice)
            {
                if (price >= lo && price <= hi)
                {
                    result.AddRange(products);
                }

                if (price < lo)
                {
                    break;
                }
            }

            return result;
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            return this.productsSortedByPrice.ContainsKey(price) == false
                ? Enumerable.Empty<IProduct>()
                : this.productsSortedByPrice[price];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (this.productsSortedByPrice.Any() == false)
            {
                throw new InvalidOperationException("Product stock is empty.");
            }

            var mostExpensiveProducts = this.productsSortedByPrice.First().Value;
            var firstAddedExpensiveProduct = mostExpensiveProducts.First();

            return firstAddedExpensiveProduct;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return this.productsByQuantity.ContainsKey(quantity) == false
                ? Enumerable.Empty<IProduct>()
                : this.productsByQuantity[quantity];
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.productsByIndex.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            this.ValidateNullProduct(product);

            var label = product.Label;

            if (this.productLabels.Contains(label) == false)
            {
                return false;
            }

            this.productsByIndex.RemoveAll(pr => pr.Label == label);
            this.RemoveProductFromCollections(product);

            return true;
        }

        public IProduct this[int index]
        {
            get
            {
                return this.Find(index);
            }
            set
            {
                this.ValidateNullProduct(value);

                this.RemoveProductFromCollections(this.Find(index));

                this.InitializeCollection(value);

                this.productsByIndex[index] = value;
            }
        }

        private void ValidateNullProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null.");
            }
        }

        private void InitializeCollection(IProduct product)
        {
            if (this.productsByQuantity.ContainsKey(product.Quantity) == false)
            {
                this.productsByQuantity[product.Quantity] = new List<IProduct>();
            }

            if (this.productsSortedByPrice.ContainsKey(product.Price) == false)
            {
                this.productsSortedByPrice[product.Price] = new List<IProduct>();
            }
        }

        private void RemoveProductFromCollections(IProduct product)
        {
            var label = product.Label;

            this.productLabels.Remove(label);
            this.productsByLabel.Remove(label);

            var allWithProductQuantity = this.productsByQuantity[product.Quantity];
            allWithProductQuantity.RemoveAll(pr => pr.Label == label);

            var allWithProductPrice = this.productsSortedByPrice[product.Price];
            allWithProductQuantity.RemoveAll(pr => pr.Label == label);
        }
    }
}
