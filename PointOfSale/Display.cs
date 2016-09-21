namespace PointOfSale
{
    public interface Display
    {
        void DisplayPrice(decimal price);
        void DisplayProductNotFoundMessage(string barcode);
        void DisplayEmptyBarcodeMessage();
        void DisplayNoSaleInProgressMessage();
        void DisplayTotal(decimal total);
    }
}