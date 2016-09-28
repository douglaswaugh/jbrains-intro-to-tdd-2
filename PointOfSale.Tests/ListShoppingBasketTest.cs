using System.Collections.Generic;
using NUnit.Framework;

namespace PointOfSale.Tests
{
    [TestFixture]
    public class ListShoppingBasketTest
    {
        [Test]
        public void Should_calculate_total_for_zero_products()
        {
            var basket = EmptyListShoppingBasket();

            Assert.That(basket.Total, Is.EqualTo(0m));
        }

        [Test]
        public void Should_calculate_total_for_one_product_product()
        {
            var basket = EmptyListShoppingBasket();

            basket.AddProduct(Product("1", 6.50m));

            Assert.That(basket.Total, Is.EqualTo(6.50m));
        }

        [Test]
        public void Should_calculate_total_for_multiple_product_products()
        {
            var basket = EmptyListShoppingBasket();

            basket.AddProduct(Product("1", 12.35m));
            basket.AddProduct(Product("2", 8.49m));
            basket.AddProduct(Product("3", 0.99m));

            Assert.That(basket.Total, Is.EqualTo(21.83m));
        }

        [Test]
        public void Should_tell_if_shopping_basket_is_empty()
        {
            var basket = EmptyListShoppingBasket();

            Assert.That(basket.Empty, Is.True);
        }

        [Test]
        public void Should_tell_if_shopping_basket_is_not_empty()
        {
            var basket = EmptyListShoppingBasket();

            basket.AddProduct(AnyProduct());

            Assert.That(basket.Empty, Is.False);
        }

        private static ListShoppingBasket EmptyListShoppingBasket()
        {
            return new ListShoppingBasket();
        }

        private Product AnyProduct()
        {
            return Product("1", 12.35m);
        }

        private Product Product(string barcode, decimal price)
        {
            return new Product(barcode, price);
        }
    }
}
