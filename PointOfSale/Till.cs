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

            if (_dictionaryCatalouge.ProductsContains(barcode))
                _display.DisplayPrice(_dictionaryCatalouge.FindPriceForProduct(barcode));
            else
                _display.DisplayProductNotFoundMessage(barcode);
        }

        private static bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }
    }
}