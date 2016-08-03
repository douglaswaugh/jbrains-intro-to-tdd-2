using System.Collections.Generic;

namespace PointOfSale
{
    public class Till
    {
        private readonly Display _display;
        private readonly Dictionary<string, string> _products;

        public Till(Display display, Dictionary<string, string> pricesByBarcode)
        {
            _display = display;
            _products = pricesByBarcode;
        }

        public void OnBarcode(string barcode)
        {
            if (BarcodeIsEmpty(barcode))
            {
                DisplayEmptyBarcodeMessage();
                return;
            }

            if (ProductsContains(barcode))
                _display.DisplayPrice(FindPriceForProduct(barcode));
            else
                DisplayProductNotFoundMessage(barcode);
        }

        private static bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }

        private bool ProductsContains(string barcode)
        {
            return _products.ContainsKey(barcode);
        }

        private string FindPriceForProduct(string barcode)
        {
            return _products[barcode];
        }

        private void DisplayProductNotFoundMessage(string barcode)
        {
            _display.Print(string.Format("Product not found for {0}", barcode));
        }

        private void DisplayEmptyBarcodeMessage()
        {
            _display.Print("Barcode empty");
        }
    }
}