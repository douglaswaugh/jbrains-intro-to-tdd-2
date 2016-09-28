using System.Collections.Generic;

namespace PointOfSale
{
    public class Catalogue
    {
        private readonly Dictionary<string, decimal> _catalogue;

        public Catalogue(Dictionary<string, decimal> catalogue)
        {
            _catalogue = catalogue;
        }

        public bool ProductsContains(string barcode)
        {
            return _catalogue.ContainsKey(barcode);
        }

        public decimal FindPriceForProduct(string barcode)
        {
            return _catalogue[barcode];
        }
    }
}