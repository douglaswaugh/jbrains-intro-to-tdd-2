using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    public class ShoppingBasket
    {
        private readonly List<KeyValuePair<string, decimal>> _pendingPurchaseBarcodePrices;

        public ShoppingBasket()
        {
            _pendingPurchaseBarcodePrices = new List<KeyValuePair<string, decimal>>();
        }

        public bool Empty => !_pendingPurchaseBarcodePrices.Any();
        public decimal Total => _pendingPurchaseBarcodePrices.Sum(p => p.Value);

        public void AddProduct(KeyValuePair<string, decimal> product)
        {
            _pendingPurchaseBarcodePrices.Add(product);
        }
    }
}