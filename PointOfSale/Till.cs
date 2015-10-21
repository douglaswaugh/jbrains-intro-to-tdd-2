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
            var product = _catalogue.GetProduct(barcode);

            if (product != null)
                _screen.Print(product);

            _screen.Print("Product not found");
        }
    }
}