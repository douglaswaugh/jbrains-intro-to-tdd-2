using System.Collections.Generic;

namespace PointOfSale
{
    public class DictionaryCatalogue
    {
        private readonly Dictionary<string, string> _catalogue;

        public DictionaryCatalogue(Dictionary<string, string> catalogue)
        {
            _catalogue = catalogue;
        }

        public bool ProductsContains(string barcode)
        {
            return _catalogue.ContainsKey(barcode);
        }

        public string FindPriceForProduct(string barcode)
        {
            return _catalogue[barcode];
        }
    }
}