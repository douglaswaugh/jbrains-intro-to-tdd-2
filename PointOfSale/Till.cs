using System.Collections.Generic;

namespace PointOfSale
{
    public class Till
    {
        private readonly Screen _screen;

        public Till(Screen screen)
        {
            _screen = screen;
        }

        public void OnBarcode(string barcode)
        {
            if (barcode == null)
                _screen.Print("Barcode null");
            else if (barcode == string.Empty)
                _screen.Print("Barcode empty");
            else
            {
                var products = new Dictionary<string, string>
                {
                    { "12341234", "£9.95" },
                    { "56785678", "£20.00" }
                };

                if (products.ContainsKey(barcode))
                {
                    _screen.Print(products[barcode]);
                }
                else
                    _screen.Print("Product not found");
            }
        }
    }
}