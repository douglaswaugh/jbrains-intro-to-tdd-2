using System;

namespace PointOfSale
{
    public class Display
    {
        private readonly Screen _screen;

        public Display(Screen screen)
        {
            _screen = screen;
        }

        public void Print(string message)
        {
            _screen.Print(message);
        }

        public void DisplayPrice(string price)
        {
            Print(price);
        }

        public void DisplayProductNotFoundMessage(string barcode)
        {
            Print($"Product not found for {barcode}");
        }

        public void DisplayEmptyBarcodeMessage()
        {
            Print("Barcode empty");
        }
    }
}