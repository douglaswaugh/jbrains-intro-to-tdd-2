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
            var basket = new ListShoppingBasket();

            Assert.That(basket.Total, Is.EqualTo(0m));
        }

        [Test]
        public void Should_calculate_total_for_one_product()
        {
            var basket = new ListShoppingBasket();

            basket.AddProduct(new KeyValuePair<string, decimal>("1", 6.50m));

            Assert.That(basket.Total, Is.EqualTo(6.50m));
        }

        [Test]
        public void Should_calculate_total_for_multiple_products()
        {
            var basket = new ListShoppingBasket();

            basket.AddProduct(new KeyValuePair<string, decimal>("1", 12.35m));
            basket.AddProduct(new KeyValuePair<string, decimal>("2", 8.49m));
            basket.AddProduct(new KeyValuePair<string, decimal>("3", 0.99m));

            Assert.That(basket.Total, Is.EqualTo(21.83m));
        }
    }
}
