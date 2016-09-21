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
    }
}
