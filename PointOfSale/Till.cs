using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    public class Till
    {
        private readonly Display _display;
        private readonly DictionaryCatalogue _catalogue;
        private readonly ShoppingBasket _shoppingBasket;

        public Till(Display display, DictionaryCatalogue dictionaryCatalogue)
        {
            _display = display;
            _catalogue = dictionaryCatalogue;
            _shoppingBasket = new ShoppingBasket();
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
                _shoppingBasket.AddProduct(new KeyValuePair<string, decimal>(barcode, price));
                _display.DisplayPrice(price);
            }
            else
            {
                _display.DisplayProductNotFoundMessage(barcode);
            }
        }

        public void OnTotal()
        {
            if (_shoppingBasket.Empty)
                _display.DisplayNoSaleInProgressMessage();
            else
                _display.DisplayTotal(_shoppingBasket.Total);
        }

        private bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }
    }
}