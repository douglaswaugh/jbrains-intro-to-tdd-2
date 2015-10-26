using System.Collections.Generic;

namespace PointOfSale
{
    public class Till
    {
        private readonly Screen _screen;
        private readonly Dictionary<string, string> _products;

        public Till(Screen screen, Dictionary<string, string> pricesByBarcode)
        {
            _screen = screen;
            _products = pricesByBarcode;
        }

        public void OnBarcode(string barcode)
        {
            if (barcode == null)
                _screen.Print("Barcode null");
            else if (barcode == string.Empty)
                _screen.Print("Barcode empty");
            else
            {
                if (_products.ContainsKey(barcode))
                {
                    _screen.Print(_products[barcode]);
                }
                else
                    _screen.Print("Product not found");
            }
        }
    }
}