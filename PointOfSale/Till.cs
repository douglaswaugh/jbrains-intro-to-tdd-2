using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    public class Till
    {
        private readonly Display _display;
        private readonly DictionaryCatalogue _catalogue;
        private decimal _total;
        private readonly List<KeyValuePair<string, decimal>> _scannedProducts;

        public Till(Display display, DictionaryCatalogue dictionaryCatalogue)
        {
            _display = display;
            _catalogue = dictionaryCatalogue;
            _scannedProducts = new List<KeyValuePair<string, decimal>>();
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
                _scannedProducts.Add(new KeyValuePair<string, decimal>(barcode, price));
                _total += price;
                _display.DisplayPrice(price);
            }
            else
            {
                _display.DisplayProductNotFoundMessage(barcode);
            }
        }

        public void OnTotal()
        {
            var saleInProgress = _total != 0m;
            if (saleInProgress)
                _display.DisplayTotal(_scannedProducts.Sum(p => p.Value));
            else
                _display.DisplayNoSaleInProgressMessage();
        }

        private static bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }
    }
}