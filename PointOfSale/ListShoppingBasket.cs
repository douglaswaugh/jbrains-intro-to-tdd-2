using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    public class ListShoppingBasket : ShoppingBasket
    {
        private readonly List<Product>_productProducts;

        public ListShoppingBasket()
        {
            _productProducts = new List<Product>();
        }

        public bool Empty => !_productProducts.Any();

        public decimal Total => _productProducts.Sum(p => p.Price);

        public void AddProduct(Product product)
        {
            _productProducts.Add(product);
        }
    }
}