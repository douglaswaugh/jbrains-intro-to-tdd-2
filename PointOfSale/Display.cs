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
    }
}