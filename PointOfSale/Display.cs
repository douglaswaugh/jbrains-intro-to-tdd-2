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
            Print(String.Format("Product not found for {0}", barcode));
        }
    }
}