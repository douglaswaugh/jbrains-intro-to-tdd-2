namespace PointOfSale
{
    public class Till
    {
        private readonly Display _display;
        private readonly DictionaryCatalogue _catalogue;
        private readonly ListShoppingBasket _concreteShoppingBasket;

        public Till(Display display, DictionaryCatalogue dictionaryCatalogue, ListShoppingBasket concreteShoppingBasket)
        {
            _display = display;
            _catalogue = dictionaryCatalogue;
            _concreteShoppingBasket = concreteShoppingBasket;
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
                _concreteShoppingBasket.AddProduct(new Product(barcode, price));

                _display.DisplayPrice(price);
            }
            else
            {
                _display.DisplayProductNotFoundMessage(barcode);
            }
        }

        public void OnTotal()
        {
            if (_concreteShoppingBasket.Empty)
                _display.DisplayNoSaleInProgressMessage();
            else
                _display.DisplayTotal(_concreteShoppingBasket.Total);
        }

        private bool BarcodeIsEmpty(string barcode)
        {
            return barcode == string.Empty;
        }
    }
}