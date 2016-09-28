namespace PointOfSale
{
    public class Product
    {
        private readonly string _barcode;
        private readonly decimal _price;

        public Product(string barcode, decimal price)
        {
            _barcode = barcode;
            _price = price;
        }

        public decimal Price => _price;

        #region equality
        protected bool Equals(Product other)
        {
            return string.Equals(_barcode, other._barcode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_barcode != null ? _barcode.GetHashCode() : 0)*397);
            }
        }
        #endregion
    }
}