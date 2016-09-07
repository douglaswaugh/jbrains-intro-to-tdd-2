namespace PointOfSale
{
    public class Till
    {
        private readonly Display _display;
        private readonly DictionaryCatalogue _catalogue;
        private decimal _total;

        public Till(Display display, DictionaryCatalogue dictionaryCatalogue)
        {
            _display = display;
            _catalogue = dictionaryCatalogue;
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
                _total = price;
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
                _display.DisplayTotal(_total);
            else
                _display.DisplayNoSaleInProgressMessage();
        }

        private static bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }
    }
}