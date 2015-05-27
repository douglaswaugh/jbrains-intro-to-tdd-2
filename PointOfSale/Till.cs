namespace PointOfSale
{
    public class Till
    {
        private readonly Screen _screen;

        public Till(Screen screen)
        {
            _screen = screen;
        }

        public void OnBarcode(string barcode)
        {
            _screen.Print("£9.95");
        }
    }
}