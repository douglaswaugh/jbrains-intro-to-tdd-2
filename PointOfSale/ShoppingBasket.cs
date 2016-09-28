namespace PointOfSale
{
    public interface ShoppingBasket
    {
        bool Empty { get; }
        decimal Total { get; }
        void AddProduct(Product product);
    }
}