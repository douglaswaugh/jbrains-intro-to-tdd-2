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
            {
                _screen.Print("Barcode null");
                return;
            }
            if (barcode == string.Empty)
            {
                _screen.Print("Barcode empty");
                return;
            }

            if (_products.ContainsKey(barcode))
                    _screen.Print(_products[barcode]);
            else
                _screen.Print(string.Format("Product not found for {0}", barcode));
        }
    }
}