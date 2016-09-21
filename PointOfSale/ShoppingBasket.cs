using System.Collections.Generic;

namespace PointOfSale
{
    public interface ShoppingBasket
    {
        bool Empty { get; }
        decimal Total { get; }
        void AddProduct(KeyValuePair<string, decimal> product);
    }
}