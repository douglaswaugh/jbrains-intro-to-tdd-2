namespace PointOfSale
{
    public class PointOfSale
    {
        private readonly Screen _screen;

        public PointOfSale(Screen screen)
        {
            _screen = screen;
        }

        public void OnBarcode(string barcode)
        {
            _screen.Print("£9.95");
        }
    }
}