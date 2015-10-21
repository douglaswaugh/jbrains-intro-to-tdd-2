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
            var product = _catalogue.GetProduct(barcode);

            _screen.Print(product);
        }
    }
}