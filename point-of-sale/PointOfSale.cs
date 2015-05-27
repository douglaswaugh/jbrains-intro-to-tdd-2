namespace PointOfSale
{
    public class PointOfSale
    {
        private string _screen;

        public PointOfSale(string screen)
        {
            _screen = screen;
        }

        public void OnBarcode(string barcode)
        {
            _screen = "£9.95";
        }
    }
}