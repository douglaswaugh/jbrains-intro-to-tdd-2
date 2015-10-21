namespace PointOfSale
{
    public class Till
    {
        private readonly Screen _screen;
        private readonly Catalogue _catalogue;

        public Till(Screen screen)
        {
            _screen = screen;
        }

        public Till(Screen screen, Catalogue catalogue)
        {
            _screen = screen;
            _catalogue = catalogue;
        }

        public void OnBarcode(string barcode)
        {
            string product = null;
            if (_catalogue != null)
             product = _catalogue.GetProduct(barcode);

            if (product != null)
                _screen.Print(product);

            _screen.Print("£9.95");
        }
    }
}