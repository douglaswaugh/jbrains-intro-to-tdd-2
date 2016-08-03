using System.Collections.Generic;

namespace PointOfSale
{
    public class DictionaryCatalogue
    {
        private Dictionary<string, string> _pricesByBarcode;

        public DictionaryCatalogue(Dictionary<string, string> pricesByBarcode)
        {
            _pricesByBarcode = pricesByBarcode;
        }

        public Dictionary<string, string> PricesByBarcode
        {
            get { return _pricesByBarcode; }
        }
    }
}