using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    public class ListShoppingBasket : ShoppingBasket
    {
        private readonly List<KeyValuePair<string, decimal>> _products;

        public ListShoppingBasket()
        {
            _products = new List<KeyValuePair<string, decimal>>();
        }

        public bool Empty => !_products.Any();

        public decimal Total => _products.Sum(p => p.Value);

        public void AddProduct(KeyValuePair<string, decimal> product)
        {
            _products.Add(product);
        }
    }
}