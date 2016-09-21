using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    public class Till
    {
        private readonly Display _display;
        private readonly DictionaryCatalogue _catalogue;
        private readonly List<KeyValuePair<string, decimal>> _pendingPurchaseProducts;

        public Till(Display display, DictionaryCatalogue dictionaryCatalogue)
        {
            _display = display;
            _catalogue = dictionaryCatalogue;
            _pendingPurchaseProducts = new List<KeyValuePair<string, decimal>>();
        }

        public void OnBarcode(string barcode)
        {
            if (BarcodeIsEmpty(barcode))
            {
                _display.DisplayEmptyBarcodeMessage();
                return;
            }

            if (_catalogue.ProductsContains(barcode))
            {
                var price = _catalogue.FindPriceForProduct(barcode);
                _pendingPurchaseProducts.Add(new KeyValuePair<string, decimal>(barcode, price));
                _display.DisplayPrice(price);
            }
            else
            {
                _display.DisplayProductNotFoundMessage(barcode);
            }
        }

        public void OnTotal()
        {
            if (_pendingPurchaseProducts.Any())
                _display.DisplayTotal(PendingPurchaseProductsTotal());
            else
                _display.DisplayNoSaleInProgressMessage();
        }

        private decimal PendingPurchaseProductsTotal()
        {
            return _pendingPurchaseProducts.Sum(p => p.Value);
        }

        private bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }
    }
}