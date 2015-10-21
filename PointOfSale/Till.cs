namespace PointOfSale
{
    public class Till
    {
        private readonly Screen _screen;
        private readonly Catalogue _catalogue;

        public Till(Screen screen, Catalogue catalogue)
        {
            _screen = screen;
            _catalogue = catalogue;
        }

        public void OnBarcode(string barcode)
        {
            if (barcode == null)
                _screen.Print("Barcode null");

            if (barcode == string.Empty)
                _screen.Print("Barcode empty");

            var product = _catalogue.GetProduct(barcode);

            if (product != null)
                _screen.Print(product);

            _screen.Print("Product not found");
        }
    }
}