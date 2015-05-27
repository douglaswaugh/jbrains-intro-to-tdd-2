namespace PointOfSale
{
    public class Screen
    {
        public string Printed { get; private set; }

        public void Print(string message)
        {
            Printed = message;
        }
    }
}