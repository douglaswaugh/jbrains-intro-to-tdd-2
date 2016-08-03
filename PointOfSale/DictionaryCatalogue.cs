using System.Collections.Generic;

namespace PointOfSale
{
    public class DictionaryCatalogue
    {
        private readonly Dictionary<string, string> _pricesByBarcode;

        public DictionaryCatalogue(Dictionary<string, string> pricesByBarcode)
        {
            _pricesByBarcode = pricesByBarcode;
        }

        public bool ProductsContains(string barcode)
        {
            return _pricesByBarcode.ContainsKey(barcode);
        }

        public string FindPriceForProduct(string barcode)
        {
            return _pricesByBarcode[barcode];
        }
    }
}