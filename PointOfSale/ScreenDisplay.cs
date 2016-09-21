namespace PointOfSale
{
    public class ScreenDisplay : Display
    {
        private readonly Screen _screen;

        public ScreenDisplay(Screen screen)
        {
            _screen = screen;
        }

        public void DisplayPrice(decimal price)
        {
            _screen.Print("£" + price);
        }

        public void DisplayProductNotFoundMessage(string barcode)
        {
            _screen.Print($"Product not found for {barcode}");
        }

        public void DisplayEmptyBarcodeMessage()
        {
            _screen.Print("Barcode empty");
        }

        public void DisplayNoSaleInProgressMessage()
        {
            _screen.Print("No sale in progress. Try scanning a product.");
        }

        public void DisplayTotal(decimal total)
        {
            _screen.Print($"Total: £{total}");
        }
    }
}