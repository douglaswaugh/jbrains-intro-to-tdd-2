namespace PointOfSale
{
    public class Till
    {
        private readonly Display _display;
        private readonly DictionaryCatalogue _dictionaryCatalouge;

        public Till(Display display, DictionaryCatalogue dictionaryCatalogue)
        {
            _display = display;
            _dictionaryCatalouge = dictionaryCatalogue;
        }

        public void OnBarcode(string barcode)
        {
            if (BarcodeIsEmpty(barcode))
            {
                _display.DisplayEmptyBarcodeMessage();
                return;
            }

            if (ProductsContains(barcode))
                _display.DisplayPrice(FindPriceForProduct(barcode));
            else
                _display.DisplayProductNotFoundMessage(barcode);
        }

        private static bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }

        private bool ProductsContains(string barcode)
        {
            return _dictionaryCatalouge.PricesByBarcode.ContainsKey(barcode);
        }

        private string FindPriceForProduct(string barcode)
        {
            return _dictionaryCatalouge.PricesByBarcode[barcode];
        }
    }
}